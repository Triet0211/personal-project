using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PizzaShopWebApplication.Models;
using PizzaShopWebApplication.Utils;
using Utils;

namespace PizzaShopWebApplication.Pages.CustomerManagement
{
    public class CreateModel : PageModel
    {
        private readonly PizzaShopWebApplication.Models.NorthwindCopyDBContext _context;

        public bool _authorized
        {
            get
            {
                return CustomAuthorization.CheckRole("ADMIN");
            }
        }

        public CreateModel(PizzaShopWebApplication.Models.NorthwindCopyDBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            if (!_authorized)
            {
                return Redirect("/Unauthorized");
            }
            return Page();
        }

        [BindProperty]
        public Customer Customer { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!_authorized)
            {
                return Redirect("/Unauthorized");
            }
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Customer cus = _context.Customers.FirstOrDefault(c => c.CustomerId == Customer.CustomerId || c.Email.ToLower() == Customer.Email.ToLower());
            if (cus != null)
            {
                ViewData["ErrorMessage"] = "Duplicate ID or email!!! Try again!";
                return Page();
            }
            _context.Customers.Add(Customer);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
