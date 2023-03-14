using Microsoft.AspNetCore.Http;
using PizzaShopWebApplication.Models;
using Utils;

namespace PizzaShopWebApplication.Utils
{
    public class CustomAuthorization
    {
        public static LoginUser loginUser
        {
            get
            {
                IHttpContextAccessor _httpContextAccessor = new HttpContextAccessor();
                return (_httpContextAccessor.HttpContext.Session.GetString("LoginUser") != null) ?
                            JsonUtils.DeserializeComplexData<LoginUser>(_httpContextAccessor.HttpContext.Session.GetString("LoginUser")) : null;
            }
        }

        public static bool CheckRole(string role)
        {
            if (loginUser == null || loginUser.Role != role)
            {
                return false;
            } else
            {
                return true;
            }
        }

        public static string Role()
        {
            return loginUser != null ? loginUser.Role : "";
        }

        public static bool CheckLoggedIn()
        {
            return (loginUser != null);
        }
    }
}
