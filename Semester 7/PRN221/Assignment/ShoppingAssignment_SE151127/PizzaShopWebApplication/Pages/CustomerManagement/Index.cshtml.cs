using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PizzaShopWebApplication.Models;
using PizzaShopWebApplication.Utils;
using Utils;

namespace PizzaShopWebApplication.Pages.CustomerManagement
{
    public class IndexModel : PageModel
    {
        private readonly PizzaShopWebApplication.Models.NorthwindCopyDBContext _context;

        public bool _authorized
        {
            get
            {
                return CustomAuthorization.CheckRole("ADMIN");
            }
        }

        public IndexModel(PizzaShopWebApplication.Models.NorthwindCopyDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public IList<Customer> Customer { get;set; }

        public IActionResult OnGet()
        {
            if (!_authorized)
            {
                return Redirect("/Unauthorized");
            }
            Customer = _context.Customers.ToList();
            return Page();
        }
    }
}
