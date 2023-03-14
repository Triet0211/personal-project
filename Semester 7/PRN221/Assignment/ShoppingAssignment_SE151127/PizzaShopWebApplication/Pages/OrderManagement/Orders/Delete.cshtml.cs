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
    public class DeleteModel : PageModel
    {
        private readonly PizzaShopWebApplication.Models.NorthwindCopyDBContext _context;

        public DeleteModel(PizzaShopWebApplication.Models.NorthwindCopyDBContext context)
        {
            _context = context;
        }
        public bool _authorized
        {
            get
            {
                return CustomAuthorization.CheckRole("ADMIN");
            }
        }

        [BindProperty]
        public Order Order { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (!_authorized)
            {
                return Redirect("/Unauthorized");
            }
            if (id == null)
            {
                return NotFound();
            }

            Order = await _context.Orders
                .Include(o => o.Customer).FirstOrDefaultAsync(m => m.OrderId == id);

            if (Order == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (!_authorized)
            {
                return Redirect("/Unauthorized");
            }
            if (id == null)
            {
                return NotFound();
            }

            Order = _context.Orders.Include(o => o.OrderDetails).FirstOrDefault(o => o.OrderId == id);
            

            if (Order != null)
            {
                foreach (OrderDetail detail in Order.OrderDetails)
                {
                    _context.OrderDetails.Remove(detail);
                }
                _context.Orders.Remove(Order);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
