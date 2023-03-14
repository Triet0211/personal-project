using SignalRAssignment_SE151127.ViewModel;
using Microsoft.AspNetCore.Http;

namespace SignalRAssignment_SE151127.Utils
{
    public static class CustomAuthorization
    {
        public static LoginUserVM loginUser
        {
            get
            {
                IHttpContextAccessor _httpContextAccessor = new HttpContextAccessor();
                return (_httpContextAccessor.HttpContext.Session.GetString("LoginUser") != null) ?
                            JsonUtils.DeserializeComplexData<LoginUserVM>(_httpContextAccessor.HttpContext.Session.GetString("LoginUser")) : null;
            }
        }
        public static void Login(LoginUserVM user)
        {
            IHttpContextAccessor _httpContextAccessor = new HttpContextAccessor();
            _httpContextAccessor.HttpContext.Session.SetString("LoginUser", JsonUtils.SerializeComplexData(user));
        }

        public static string Role()
        {
            return loginUser != null ? loginUser.Role : "";
        }

        public static int UserId()
        {
            return loginUser != null ? loginUser.Id : 0;
        }
    }
}
