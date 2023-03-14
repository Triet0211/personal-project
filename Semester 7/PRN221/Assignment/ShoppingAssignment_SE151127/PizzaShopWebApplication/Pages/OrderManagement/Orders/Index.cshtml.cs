using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PizzaShopWebApplication.Models;
using PizzaShopWebApplication.Utils;
using Utils;

namespace PizzaShopWebApplication.Pages.OrderManagement.Orders
{
    public class IndexModel : PageModel
    {
        private readonly PizzaShopWebApplication.Models.NorthwindCopyDBContext _context;

        public IndexModel(PizzaShopWebApplication.Models.NorthwindCopyDBContext context)
        {
            _context = context;
        }

        public IList<Order> Order { get;set; }

        public IActionResult OnGet()
        {
            if (CustomAuthorization.loginUser == null)
            {
                return Redirect("/Unauthorized");
            }
            if (CustomAuthorization.Role() == "CUSTOMER")
            {
                Order = _context.Orders
                 .Include(o => o.Customer).Where(o => o.CustomerId == CustomAuthorization.loginUser.Id).ToList();
            } else
            {
                Order = _context.Orders
                 .Include(o => o.Customer).ToList();
            }
            return Page();
        }
    }
}
