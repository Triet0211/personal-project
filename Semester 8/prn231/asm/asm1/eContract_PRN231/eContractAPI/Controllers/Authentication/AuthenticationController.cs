using BusinessObject.Models;
using DataAccess.Repositories;
using eStoreAPI.Models;
using Google.Apis.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Utils;
using Utils.Authentication;

namespace eRecruitmentAPI.Controllers.Authentication
{
    [Route("api/auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        IUserRepository userRepo;

        private readonly JwtToken _jwtToken;
        public AuthenticationController(JwtToken jwtToken)
        {
            userRepo = new UserRepository();
            _jwtToken = jwtToken;
        }

        [AllowAnonymous]
        [HttpPost("signin")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<LoginUser> Login([FromBody] User user)
        {
            try
            {
                var userDB = userRepo.GetUserByEmail(user.Email);
                if (userDB == null)
                {
                    user.Id = Guid.NewGuid().ToString();
                    user.Role = CommonEnums.ROLE.NONE;
                    user.CreatedAt = DateTime.Now;
                    user.HiddenData = "{}";
                    userRepo.RegisterUser(user);
                    userDB = userRepo.GetUserByEmail(user.Email);
                }
                string accessToken = _jwtToken.GenerateAccessToken(userDB);
                string refreshToken = _jwtToken.GenerateRefreshToken(userDB);
                userRepo.InsertRefreshToken(refreshToken, userDB.Id);
                userDB = userRepo.GetUserByEmail(user.Email);
                LoginUser res = new LoginUser(userDB, accessToken, refreshToken);
                return res;
            } catch (Exception e)
            {
                return AuthenticationResponse.Failed();
            }
        }

        [AllowAnonymous]
        [HttpGet("accesstoken")]
        public IActionResult GenerateAccessTokenFromRefreshToken([FromBody] string refreshToken)
        {
            var authTokenDb = userRepo.GetRefreshToken(refreshToken);
            var userData = _jwtToken.ValidateRefreshToken(refreshToken);

            if (userData == null || authTokenDb == null || authTokenDb.UserId != userData.Id)
            {
                return AuthenticationResponse.Failed();
            }

            var user = userRepo.GetUserByEmail(userData.Email);
            var newAccessToken = _jwtToken.GenerateAccessToken(user);
            return AuthenticationResponse.Success(RefreshToken: "", AccessToken: newAccessToken);
        }

        [HttpGet("signout")]
        public IActionResult Logout([FromBody] string refreshToken)
        {
            userRepo.DeleteAuthToken(refreshToken);
            return Ok();
        }
    }
}
