using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace StackOverFlow.Models
{
    public partial class Answer
    {
        public int AnswerId { get; set; }
        [Required]
        public int QuestionId { get; set; }
        [Required]
        public int UserId { get; set; }
        public string Answer1 { get; set; }
        [Required]
        public int Vote { get; set; }

        public virtual Question Question { get; set; }
        public virtual AppUser User { get; set; }
    }
}
