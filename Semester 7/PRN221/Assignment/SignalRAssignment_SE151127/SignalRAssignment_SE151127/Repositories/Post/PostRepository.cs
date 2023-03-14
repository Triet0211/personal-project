using SignalRAssignment_SE151127.DataAccess;
using SignalRAssignment_SE151127.Models;
using System.Collections.Generic;

namespace SignalRAssignment_SE151127.Repositories
{
    public class PostRepository : IPostRepository
    {
        private PostDAO _postDao;

        public PostRepository(PostDAO postDAO)
        {
            _postDao = postDAO;
        }
        public IEnumerable<Post> GetAll()
        {
            return _postDao.GetAll();
        }

        public IEnumerable<Post> GetAll(string includes)
        {
            return _postDao.GetAll(null, null, includes);
        }

        public Post GetById(int id, string? includes)
        {
            if (includes == null)
            {
                return _postDao.Get(id);
            } else
            {
                return _postDao.GetFirstOrDefault(p => p.PostId == id, includes);
            }
        }

        public void Add(Post post)
        {
            _postDao.AddPost(post);
        }

        public void UpdatePost(Post post)
        {
            _postDao.UpdatePost(post);
        }

        public void DeletePost(int id)
        {
            _postDao.Remove(id);
        }
    }
}