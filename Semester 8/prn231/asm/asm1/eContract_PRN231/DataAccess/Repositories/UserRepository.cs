using BusinessObject.Models;
using DataAccess.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private UserDAO userDAO
        {
            get
            {
                return new UserDAO();
            }
        }

        public User GetUserByEmail(string email)
        {
            return userDAO.GetUserByEmail(email);
        }

        public void RegisterUser(User user)
        {
            userDAO.CreateUser(user);
        }

        public void InsertRefreshToken(string refreshToken, string userId)
        {
            userDAO.InsertRefreshToken(refreshToken, userId);
        }

        public AuthToken GetRefreshToken(string refreshToken)
        {
            return userDAO.GetAuthTokenByRefreshToken(refreshToken);
        }
        public void DeleteAuthToken(string refreshToken)
        {
            userDAO.DeleteAuthToken(refreshToken);
        }
    }
}
