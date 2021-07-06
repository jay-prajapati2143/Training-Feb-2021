using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StackOverFlow.Models;
using StackOverFlow.Models.Authentication;
using StackOverFlow.UnitOfWorkPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StackOverFlow.Controllers
{
 
    //[Authorize(Roles = UserRoles.Admin)]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> userManager;
        public AdminController(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager)
        {
            this._unitOfWork = unitOfWork;
            this.userManager = userManager;
        }
        [HttpGet]
        public ActionResult<List<AppUser>> GetAllUser()
        {
            //var admin = userManager.Users.FirstOrDefault(a => a.UserName == User.Identity.Name);
            //if(_unitOfWork.AppUsers.ValidateUser(admin.Id,))
            var users = _unitOfWork.AppUsers.GetAll().ToList();
            return users;
        }

        [HttpGet("{id}")]
        public ActionResult<AppUser> GetUserId(int id)
        {
            var user = _unitOfWork.AppUsers.GetById(id);
            return user;
        }
        

        [HttpDelete("{id}")]
        public async Task<ActionResult<AppUser>> DeleteUser(int id)
        {
            
            var appUser = _unitOfWork.AppUsers.GetById(id);
            var user = await userManager.FindByIdAsync(appUser.ApplicationUserId);
           
            _unitOfWork.AppUsers.Remove(appUser);
            _unitOfWork.Complete();
            _unitOfWork.Dispose();
            return Ok();
        }
    }
}
