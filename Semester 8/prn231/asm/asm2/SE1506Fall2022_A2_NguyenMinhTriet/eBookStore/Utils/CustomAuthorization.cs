using BusinessObject;
using Microsoft.AspNetCore.Http;

namespace eBookStore.Utils
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

        public static bool CheckRole(int role)
        {
            if (loginUser == null || loginUser.Role != role)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static int Role()
        {
            return loginUser != null ? loginUser.Role : -1;
        }

        public static bool CheckLoggedIn()
        {
            return (loginUser != null);
        }
    }
}
