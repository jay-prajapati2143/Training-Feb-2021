using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace StackOverFlow.Models
{
    public partial class IndustriesToExclude
    {
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }

        [Required]
        public string IndustryToExclude { get; set; }

        public virtual AppUser User { get; set; }
    }
}
