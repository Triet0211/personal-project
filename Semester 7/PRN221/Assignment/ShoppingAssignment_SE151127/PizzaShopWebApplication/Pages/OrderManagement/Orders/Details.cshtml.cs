using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PizzaShopWebApplication.Models;
using PizzaShopWebApplication.Utils;

namespace PizzaShopWebApplication.Pages.OrderManagement.Orders
{
    public class DetailsModel : PageModel
    {
        private readonly PizzaShopWebApplication.Models.NorthwindCopyDBContext _context;

        public DetailsModel(PizzaShopWebApplication.Models.NorthwindCopyDBContext context)
        {
            _context = context;
        }

        public IList<OrderDetail> OrderDetail { get;set; }

        public IActionResult OnGetAsync(string id)
        {   
            if (CustomAuthorization.loginUser == null)
            {
                return Redirect("/Unauthorized");
            }
            OrderDetail = _context.OrderDetails
                .Include(o => o.Order)
                .Include(o => o.Product).Where(o => o.OrderId == id).ToList();
            return Page();
        }
    }
}
