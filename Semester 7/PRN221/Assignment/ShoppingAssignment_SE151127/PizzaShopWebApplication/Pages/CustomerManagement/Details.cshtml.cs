using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PizzaShopWebApplication.Models;
using Utils;

namespace PizzaShopWebApplication.Pages.CustomerManagement
{
    public class DetailsModel : PageModel
    {
        private readonly PizzaShopWebApplication.Models.NorthwindCopyDBContext _context;
        public LoginUser loginUser
        {
            get
            {
                IHttpContextAccessor _httpContextAccessor = new HttpContextAccessor();
                return (_httpContextAccessor.HttpContext.Session.GetString("LoginUser") != null) ?
                            JsonUtils.DeserializeComplexData<LoginUser>(_httpContextAccessor.HttpContext.Session.GetString("LoginUser")) : null;
            }
        }

        public DetailsModel(PizzaShopWebApplication.Models.NorthwindCopyDBContext context)
        {
            _context = context;
        }

        public Customer Customer { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (loginUser == null)
            {
                return Redirect("/Unauthorized");
            }
            if (id == null)
            {
                return NotFound();
            }
            Customer = await _context.Customers.FirstOrDefaultAsync(m => m.CustomerId == id);
            if (Customer == null)
            {
                return NotFound();
            }
            if (loginUser.Role == "CUSTOMER")
            {
                if (Customer.Email != loginUser.Email || Customer.CustomerId != loginUser.Id)
                {
                    return Redirect("/Unauthorized");
                }
            }
            return Page();
        }
    }
}
