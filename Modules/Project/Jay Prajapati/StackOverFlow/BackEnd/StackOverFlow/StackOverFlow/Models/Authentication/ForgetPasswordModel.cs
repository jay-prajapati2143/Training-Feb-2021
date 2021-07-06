using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StackOverFlow.Models.Authentication
{
    public class ForgetPasswordModel
    {
        [Required]
        //[EmailAddress]
        public string UserName { get; set; }
    }
}
