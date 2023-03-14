using System;
using System.Collections.Generic;
using SignalRAssignment_SE151127.Models;

namespace SignalRAssignment_SE151127.Repositories
{
    public interface ICategoryRepository
    {
        public IEnumerable<PostCategory> GetAll();
        public PostCategory GetById(int id);
    }
}