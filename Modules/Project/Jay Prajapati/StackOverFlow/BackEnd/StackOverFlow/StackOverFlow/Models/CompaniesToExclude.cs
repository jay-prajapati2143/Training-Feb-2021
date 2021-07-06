﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace StackOverFlow.Models
{
    public partial class CompaniesToExclude
    {
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
#nullable disable
        [Required]
        public string CompanyToExclude { get; set; }


        public virtual AppUser User { get; set; }
    }
}
