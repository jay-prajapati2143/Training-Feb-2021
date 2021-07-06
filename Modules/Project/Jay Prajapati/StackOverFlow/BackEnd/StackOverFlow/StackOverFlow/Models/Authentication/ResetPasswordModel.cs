using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StackOverFlow.Models.Authentication
{
    public class ResetPasswordModel
    {
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The Password and confirmPassword does not match.")]
        public string ConfirmPassword { get; set; }

        public string UserName { get; set; }
        public string Token { get; set; }


    }
}
