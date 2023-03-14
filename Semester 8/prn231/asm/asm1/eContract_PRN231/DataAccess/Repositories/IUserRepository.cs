using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public interface IUserRepository
    { 
        User GetUserByEmail(string email);
        void RegisterUser (User user);
        public void InsertRefreshToken(string refreshToken, string userId);
        public AuthToken GetRefreshToken(string refreshToken);
        public void DeleteAuthToken(string refreshToken);

    }
}
