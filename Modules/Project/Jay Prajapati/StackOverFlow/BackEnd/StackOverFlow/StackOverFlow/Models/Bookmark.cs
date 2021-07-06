using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace StackOverFlow.Models
{
    public partial class Bookmark
    {
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int QuestionId { get; set; }

        public virtual Question Question { get; set; }
        public virtual AppUser User { get; set; }
    }
}
