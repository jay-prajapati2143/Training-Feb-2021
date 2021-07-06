using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using StackOverFlow.Code.Services;
using StackOverFlow.Code.Services.Email;
using StackOverFlow.Models;
using StackOverFlow.Models.Authentication;
using StackOverFlow.UnitOfWorkPattern;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace StackOverFlow.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {

        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmailSender _emailSender;
        private readonly IMailService _mailService;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AuthenticateController(UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IConfiguration configuration,
            SignInManager<ApplicationUser> signInManager,
            IUnitOfWork unitOfWork,
            IEmailSender emailSender,
            IMailService mailService) 

        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            _configuration = configuration;
            _unitOfWork = unitOfWork;
            _emailSender = emailSender;
            _signInManager = signInManager;
            _mailService = mailService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = await userManager.FindByNameAsync(model.Username);
            if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
            {

                var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);
                if (!result.Succeeded)
                {
                    // For Email Verification
                    var userFromDb = await userManager.FindByNameAsync(user.UserName);

                    var emailtoken = await userManager.GenerateEmailConfirmationTokenAsync(userFromDb);

                    var uriBuilder = new UriBuilder(_configuration["ReturnPaths:ConfirmEmail"]);
                    var query = HttpUtility.ParseQueryString(uriBuilder.Query);
                    query["token"] = emailtoken;
                    query["userid"] = userFromDb.Id;
                    uriBuilder.Query = query.ToString();
                    var urlString = uriBuilder.ToString();


                    //var senderEmail = _configuration["ReturnPaths:SenderEmail"];
                    //await _emailSender.SendEmailAsync(senderEmail, userFromDb.Email, "Confirm your email address", urlString);

                    // new Implementation
                    var emailstruct = new MailRequest();
                    emailstruct.Subject = "Confirm your email address";
                    emailstruct.Body = $"<a href=\"{urlString}\" style=\"text-decoration: none;\">Verify Email</a>";
                    emailstruct.ToEmail = userFromDb.Email;
                    await _mailService.SendEmailAsync(emailstruct);

                    return Ok(new
                    {
                        Status = "Fail",
                        Message = "User Email is Not Varified! Please verify email first"
                    });
                }
                var userRoles = await userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    //new Claim(ClaimTypes.NameIdentifier,user.Id),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(3),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );

                var appUser = _unitOfWork.AppUsers.Find(u => u.ApplicationUserId == user.Id).First();
                appUser.VisitedDays += 1;
                appUser.LastSeen = DateTime.Now;
                _unitOfWork.AppUsers.UpdateUser(appUser.UserId, appUser);
                _unitOfWork.Complete();
                _unitOfWork.Dispose();

                //var res = new Response { Status = "Success", Message = "User Login Sucessfully!" };
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo,
                    Status = "Success",
                    Message = "User Login Successfully!",
                    user = appUser.UserId
                }) ;
            }
            return Ok(new { Status = "Fail", Message = "Invalid UserName or Password!" });
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var userExists = await userManager.FindByNameAsync(model.Username);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exists!" });

            ApplicationUser user = new ApplicationUser()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username
            };
            var result = await userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                // For Email Verification
                var userFromDb = await userManager.FindByNameAsync(user.UserName);

                var token = await userManager.GenerateEmailConfirmationTokenAsync(userFromDb);

                var uriBuilder = new UriBuilder(_configuration["ReturnPaths:ConfirmEmail"]);
                var query = HttpUtility.ParseQueryString(uriBuilder.Query);
                query["token"] = token;
                query["userid"] = userFromDb.Id;
                uriBuilder.Query = query.ToString();
                var urlString = uriBuilder.ToString();


                //var senderEmail = _configuration["ReturnPaths:SenderEmail"];
                //await _emailSender.SendEmailAsync(senderEmail, userFromDb.Email, "Confirm your email address", urlString);

                // new Implementation
                var emailstruct = new MailRequest();
                emailstruct.Subject = "Confirm your email address";
                emailstruct.Body = $"<a href=\"{urlString}\" style=\"text-decoration: none;\">Verify Email</a>";
                emailstruct.ToEmail = userFromDb.Email;
                await _mailService.SendEmailAsync(emailstruct);



                // End Email Verification
                AppUser u = new AppUser()
                {
                    FullName = model.FullName,
                    VisitedDays = 0,
                    Reputation = 0,
                    ProfileViews = 0,
                    ApplicationUserId = user.Id
                };

                _unitOfWork.AppUsers.Add(u);
                _unitOfWork.Complete();
                _unitOfWork.Dispose();
                return Ok(new Response { Status = "Success", Message = "User created successfully!" });
                
            }

            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." });
        }

        [HttpPost]
        [Route("ResetPasswordToken")]
        public async Task<IActionResult> GetResetPasswordToken(ForgetPasswordModel model)
        {
            //var Appuser = _unitOfWork.AppUsers.GetById(userId);
            var userFromDb = await userManager.FindByNameAsync(model.UserName);
            if (User == null)
            {
                return BadRequest();
            }
            
            var token = await userManager.GeneratePasswordResetTokenAsync(userFromDb);

            var uriBuilder = new UriBuilder(_configuration["PwdReturnPaths:ResetPassword"]);
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            query["token"] = token;
            query["userid"] = userFromDb.Id;
            uriBuilder.Query = query.ToString();
            var urlString = uriBuilder.ToString();


            //var senderEmail = _configuration["PwdReturnPaths:SenderEmail"];
            //await _emailSender.SendEmailAsync(senderEmail, userFromDb.Email, "Reset Password", urlString);


            // new Implementation
            var emailstruct = new MailRequest();
            emailstruct.Subject = "Reset Password";
            emailstruct.Body = $"<a href=\"{urlString}\" style=\"text-decoration: none;\">Reset Your Password</a>";
            emailstruct.ToEmail = userFromDb.Email;
            
            await _mailService.SendEmailAsync(emailstruct);


            return Ok(new Response { Status = "Success", Message = "Please Check your email for reset password." });
        }

        [HttpPost]
        [Route("ResetPassword")]
        public async Task<IActionResult> ResetPassword(ResetPasswordModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var user = await userManager.FindByNameAsync(model.UserName);
            
            if(user == null)
            {
                return BadRequest();
            }
            var result = await userManager.ResetPasswordAsync(user, model.Token, model.Password);
            if (result.Succeeded)
            {
                return Ok(new Response { Status = "Success", Message = "Password Changed Successfully." });
            }
            return BadRequest();
        }




        [HttpPost]
        [Route("verifyEmail")]
        public async Task<IActionResult> ConfirmEmail(ConfirmEmailViewModel model)
        {
            var user = await userManager.FindByIdAsync(model.UserId);
            var result = await userManager.ConfirmEmailAsync(user, model.Token);
            if (result.Succeeded) {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("register-admin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterModel model)
        {
            var userExists = await userManager.FindByNameAsync(model.Username);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exists!" });

            ApplicationUser user = new ApplicationUser()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username
            };
            var result = await userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." });

            if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
            if (!await roleManager.RoleExistsAsync(UserRoles.User))
                await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

            if (await roleManager.RoleExistsAsync(UserRoles.Admin))
            {
                await userManager.AddToRoleAsync(user, UserRoles.Admin);
            }

            AppUser u = new AppUser()
            {
                FullName = model.FullName,
                VisitedDays = 0,
                Reputation = 0,
                ProfileViews = 0,
                ApplicationUserId = user.Id
            };

            _unitOfWork.AppUsers.Add(u);
            _unitOfWork.Complete();
            _unitOfWork.Dispose();

            return Ok(new Response { Status = "Success", Message = "User created successfully!" });
        }
    }
}
