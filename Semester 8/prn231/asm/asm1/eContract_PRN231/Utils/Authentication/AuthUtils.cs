using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Authentication
{
    public static class AuthUtils
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
        public static void Login(LoginUser user)
        {
            IHttpContextAccessor _httpContextAccessor = new HttpContextAccessor();
            _httpContextAccessor.HttpContext.Session.SetString("LoginUser", JsonUtils.SerializeComplexData(user));
        }
    }
}
