using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class UserDAO : BaseDAO<User>
    {
        private readonly eRecruitmentContext _dbContext;

        public UserDAO()
        {
            _dbContext = new eRecruitmentContext();
        }

        public void CreateUser(User user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
        }

        public User GetUserByEmail(string email)
            => _dbContext.Users.ToList().FirstOrDefault(user => user.Email == email);

        public void InsertRefreshToken(string refreshToken, string userId)
        {
            List<AuthToken> listCurrentUserToken = _dbContext.AuthTokens.Where(token => token.UserId == userId).ToList();
            foreach(AuthToken token in listCurrentUserToken)
            {
                _dbContext.AuthTokens.Remove(token);
            }
            string guid = Guid.NewGuid().ToString();
            AuthToken authToken = new AuthToken()
            {
                Id = guid,
                CreatedAt = DateTime.Now,
                RefreshToken = refreshToken,
                UserId = userId,
            };
            _dbContext.AuthTokens.Add(authToken);
            _dbContext.SaveChanges();
        }

        public AuthToken GetAuthTokenByRefreshToken(string refreshToken)
        {
            AuthToken authToken = _dbContext.AuthTokens.FirstOrDefault(token => token.RefreshToken == refreshToken);
            return authToken;
        }

        public void DeleteAuthToken(string refreshToken)
        {
            AuthToken authToken = _dbContext.AuthTokens.FirstOrDefault(token => token.RefreshToken == refreshToken);
            _dbContext.AuthTokens.Remove(authToken);
            _dbContext.SaveChanges();
        }
    }
}
