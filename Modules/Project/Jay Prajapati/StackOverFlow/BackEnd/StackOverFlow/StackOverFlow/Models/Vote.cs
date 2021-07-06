using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StackOverFlow.Models
{
    public class Vote
    {
        public int VoteId { get; set; }
        [Required]
        public int AppUserId { get; set; }
        public AppUser appUser { get; set; }
#nullable enable
        public int? QuestionId { get; set; }
        public Question? question { get; set; }
        public int? AnswerId { get; set; }
        public Answer? answer { get; set; }
#nullable disable
        public DateTime timeOfVote { get; set; }

    }
}
