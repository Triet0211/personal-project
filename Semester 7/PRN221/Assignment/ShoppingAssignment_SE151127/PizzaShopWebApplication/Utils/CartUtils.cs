using Microsoft.AspNetCore.Http;
using PizzaShopWebApplication.Models;
using Utils;

namespace PizzaShopWebApplication.Utils
{
    public static class CartUtils
    {
        public static Cart Cart
        {
            get
            {
                IHttpContextAccessor _httpContextAccessor = new HttpContextAccessor();
                return (_httpContextAccessor.HttpContext.Session.GetString("Cart") != null) ?
                            JsonUtils.DeserializeComplexData<Cart>(_httpContextAccessor.HttpContext.Session.GetString("Cart")) : null;
            }
        }

        public static void SetCartInSession(Cart cart)
        {
            IHttpContextAccessor _httpContextAccessor = new HttpContextAccessor();
            _httpContextAccessor.HttpContext.Session.SetString("Cart", JsonUtils.SerializeComplexData(cart));
        }

        public static void DeleteCartInSession()
        {
            IHttpContextAccessor _httpContextAccessor = new HttpContextAccessor();
            _httpContextAccessor.HttpContext.Session.Remove("Cart");
        }
    }
}