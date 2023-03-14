using Microsoft.EntityFrameworkCore;
using SignalRAssignment_SE151127.Models;
using System.Linq;

namespace SignalRAssignment_SE151127.DataAccess
{
    public class UserDAO : BaseDAO<AppUser>
    {
        private readonly ApplicationDBContext _dbContext;

        public UserDAO(ApplicationDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public void UpdateUser(AppUser user)
        {
            var local = _dbContext.Set<AppUser>()
                .Local
                .FirstOrDefault(entry => entry.UserId == user.UserId);
            if (local != null)
            {
                _dbContext.Entry(local).State = EntityState.Detached;
            }
            _dbContext.Entry(user).State = EntityState.Modified;
            _dbContext.AppUsers.Update(user);
            _dbContext.SaveChanges();
        }
    }
}
