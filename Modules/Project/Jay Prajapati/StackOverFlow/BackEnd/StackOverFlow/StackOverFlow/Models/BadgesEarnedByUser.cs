using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace StackOverFlow.Models
{
    public partial class BadgesEarnedByUser
    {
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int BadgeId { get; set; }
        [Required]
        public DateTime DateOfEarned { get; set; }

        public virtual Badge Badge { get; set; }
        public virtual AppUser User { get; set; }
    }
}
