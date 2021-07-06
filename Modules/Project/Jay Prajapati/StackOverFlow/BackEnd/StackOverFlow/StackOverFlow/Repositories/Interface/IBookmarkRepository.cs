﻿using StackOverFlow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StackOverFlow.Repositories.Interface
{
    public interface IBookmarkRepository : IGenericRepository<Bookmark> 
    {
        public IList<Question> GetBookmarkedDetails(int userId);
    }
}