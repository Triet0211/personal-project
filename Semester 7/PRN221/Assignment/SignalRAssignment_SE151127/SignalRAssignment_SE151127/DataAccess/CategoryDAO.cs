using SignalRAssignment_SE151127.Models;

namespace SignalRAssignment_SE151127.DataAccess
{
    public class CategoryDAO : BaseDAO<PostCategory>
    {
        private readonly ApplicationDBContext _dbContext;

        public CategoryDAO(ApplicationDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
