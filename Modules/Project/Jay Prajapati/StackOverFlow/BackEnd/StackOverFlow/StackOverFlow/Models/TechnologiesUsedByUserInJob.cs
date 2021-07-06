using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace StackOverFlow.Models
{
    public partial class TechnologiesUsedByUserInJob
    {
        public int UserId { get; set; }
        [Required]
        public string Technologies { get; set; }

        public virtual AppUser User { get; set; }
    }
}
