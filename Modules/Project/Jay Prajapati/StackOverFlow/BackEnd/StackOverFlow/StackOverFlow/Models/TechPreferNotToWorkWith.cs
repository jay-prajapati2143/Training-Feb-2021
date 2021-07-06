using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace StackOverFlow.Models
{
    public partial class TechPreferNotToWorkWith
    {
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public string TechPeferNotToWorkWith { get; set; }

        public virtual AppUser User { get; set; }
    }
}
