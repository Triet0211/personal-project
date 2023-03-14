using System;
using System.Collections.Generic;
using SignalRAssignment_SE151127.Models;
using SignalRAssignment_SE151127.ViewModel;

namespace SignalRAssignment_SE151127.Repositories
{
    public interface IPostRepository
    {
        public IEnumerable<Post> GetAll();
        public Post GetById(int id, string? includes);
        public void Add(Post post);
        public void UpdatePost(Post post);
        public void DeletePost(int id);
        public IEnumerable<Post> GetAll(string includes);
    }
}
