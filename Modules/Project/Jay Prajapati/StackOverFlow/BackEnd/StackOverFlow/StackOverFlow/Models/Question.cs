using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace StackOverFlow.Models
{
    public partial class Question
    {
        public Question()
        {
            Answers = new HashSet<Answer>();
            Bookmarks = new HashSet<Bookmark>();
            Tags = new HashSet<Tag>();
        }

        public int QuestionId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public string Question1 { get; set; }
        public string QuestionBody { get; set; } // new column Added
        [Required]
        public int TotalViews { get; set; }
        [Required]
        public int Vote { get; set; }
        [Required]
        public DateTime TimeOfAsk { get; set; }

        public virtual AppUser User { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
        public virtual ICollection<Bookmark> Bookmarks { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
    }
}
