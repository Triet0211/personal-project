using Microsoft.EntityFrameworkCore;
using SignalRAssignment_SE151127.Models;
using System.Linq;

namespace SignalRAssignment_SE151127.DataAccess
{
    public class PostDAO : BaseDAO<Post>
    {
        private readonly ApplicationDBContext _dbContext;

        public PostDAO(ApplicationDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddPost(Post post)
        {
            AppUser author = _dbContext.AppUsers.Find(post.Author.UserId);
            PostCategory cate = _dbContext.PostCategories.Find(post.Category.CategoryId);
            _dbContext.Entry(author).State = EntityState.Unchanged;
            _dbContext.Entry(cate).State = EntityState.Unchanged;
            _dbContext.Posts.Add(post);
            _dbContext.SaveChanges();
        }

        public void UpdatePost(Post post)
        {
            var local = _dbContext.Set<Post>()
                .Local
                .FirstOrDefault(entry => entry.PostId == post.PostId);
            if (local != null)
            {
                _dbContext.Entry(local).State = EntityState.Detached;
            }
            _dbContext.Entry(post).State = EntityState.Modified;

            _dbContext.Posts.Update(post);
            _dbContext.SaveChanges();
        }
    }
}
