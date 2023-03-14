using BusinessObject;
using DataAccess.Repository;
using System.Collections.Generic;

namespace DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        public IEnumerable<User> GetUsers() => UserDAO.Instance.GetUserList();
        public User GetUserByID(int userId) => UserDAO.Instance.GetUserByID(userId);
        public User GetUserByEmail(string email) => UserDAO.Instance.GetUserByEmail(email);
        public void InsertUser(User user) => UserDAO.Instance.AddUser(user);
        public void DeleteUser(int userId) => UserDAO.Instance.Remove(userId);
        public void UpdateUser(User user) => UserDAO.Instance.Update(user);
        public LoginUser Login(string email, string password) => UserDAO.Instance.Login(email, password);
        public IEnumerable<User> GetUsersByEmail(string email) => UserDAO.Instance.SearchUsersByEmail(email);
        public IEnumerable<User> SortUsers() => UserDAO.Instance.SortByEmail;
    }
}
