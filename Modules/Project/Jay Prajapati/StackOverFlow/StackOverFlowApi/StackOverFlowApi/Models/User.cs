﻿using StackOverFlowApi.Models.Authentication;
using System;
using System.Collections.Generic;

#nullable disable

namespace StackOverFlowApi.Models
{
    public partial class User
    {
        public User()
        {
            Answers = new HashSet<Answer>();
            BadgesEarnedByUsers = new HashSet<BadgesEarnedByUser>();
            Bookmarks = new HashSet<Bookmark>();
            CompaniesToExcludes = new HashSet<CompaniesToExclude>();
            Educations = new HashSet<Education>();
            IndustriesToExcludes = new HashSet<IndustriesToExclude>();
            JobProfiles = new HashSet<JobProfile>();
            Questions = new HashSet<Question>();
            TechPreferNotToWorkWiths = new HashSet<TechPreferNotToWorkWith>();
            TechWantToWorkWiths = new HashSet<TechWantToWorkWith>();
            TechnologiesUsedAsStudents = new HashSet<TechnologiesUsedAsStudent>();
            WhereUserLikeToWorks = new HashSet<WhereUserLikeToWork>();
            WorkExperiences = new HashSet<WorkExperience>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Title { get; set; }
        public int? VisitedDays { get; set; }
        public string GitHub { get; set; }
        public string Twitter { get; set; }
        public string Location { get; set; }
        public DateTime? LastSeen { get; set; }
        public int? ProfileViews { get; set; }
        public string AboutUser { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailId { get; set; }
        public int ApplicationUserId { get; set; }
        public ApplicationUser AppUser { get; set; }

        public virtual ICollection<Answer> Answers { get; set; }
        public virtual ICollection<BadgesEarnedByUser> BadgesEarnedByUsers { get; set; }
        public virtual ICollection<Bookmark> Bookmarks { get; set; }
        public virtual ICollection<CompaniesToExclude> CompaniesToExcludes { get; set; }
        public virtual ICollection<Education> Educations { get; set; }
        public virtual ICollection<IndustriesToExclude> IndustriesToExcludes { get; set; }
        public virtual ICollection<JobProfile> JobProfiles { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<TechPreferNotToWorkWith> TechPreferNotToWorkWiths { get; set; }
        public virtual ICollection<TechWantToWorkWith> TechWantToWorkWiths { get; set; }
        public virtual ICollection<TechnologiesUsedAsStudent> TechnologiesUsedAsStudents { get; set; }
        public virtual ICollection<WhereUserLikeToWork> WhereUserLikeToWorks { get; set; }
        public virtual ICollection<WorkExperience> WorkExperiences { get; set; }
    }
}