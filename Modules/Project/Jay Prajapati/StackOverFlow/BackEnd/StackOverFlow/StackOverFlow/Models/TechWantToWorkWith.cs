using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace StackOverFlow.Models
{
    public partial class TechWantToWorkWith
    {
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public string TechYouWantToWorkWith { get; set; }

        public virtual AppUser User { get; set; }
    }
}
