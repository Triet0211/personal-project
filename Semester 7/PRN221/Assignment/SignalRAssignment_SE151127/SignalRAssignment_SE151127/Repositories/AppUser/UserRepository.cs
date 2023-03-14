using SignalRAssignment_SE151127.DataAccess;
using SignalRAssignment_SE151127.Models;

namespace SignalRAssignment_SE151127.Repositories
{
    public class UserRepository : IUserRepository
    {
        private UserDAO _userDao;

        public UserRepository(UserDAO userDAO)
        {
            _userDao = userDAO;
        }
        public System.Collections.Generic.IEnumerable<AppUser> GetAll()
        {
            return _userDao.GetAll();
        }

        public AppUser GetByEmail(string email)
        {
            return _userDao.GetFirstOrDefault(user => user.Email.ToLower().Equals(email.ToLower()));
        }

        public AppUser GetById(int id)
        {
            return _userDao.Get(id);
        }

        public void Register(AppUser user)
        {
            _userDao.Add(user);
        }

        public void Update(AppUser user)
        {
            _userDao.UpdateUser(user);
        }

        public void DeleteUser(int id)
        {
            _userDao.Remove(id);
        }
    }
}
