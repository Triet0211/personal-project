using BusinessObject;
using System.Collections.Generic;


namespace DataAccess.Repository
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();
        User GetUserByID(int userId);
        User GetUserByEmail(string email);
        void InsertUser(User user);
        void DeleteUser(int userId);
        void UpdateUser(User user);
        LoginUser Login(string email, string password);
        IEnumerable<User> GetUsersByEmail(string email);
        IEnumerable<User> SortUsers();
    }
}