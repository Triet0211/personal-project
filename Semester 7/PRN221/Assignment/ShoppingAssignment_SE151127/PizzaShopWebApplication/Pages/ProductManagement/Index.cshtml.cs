using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PizzaShopWebApplication.Models;
using PizzaShopWebApplication.Utils;

namespace PizzaShopWebApplication.Pages.ProductManagement
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

        public IList<Product> Product { get;set; }

        public IActionResult OnGet()
        {
            if(!_authorized)
            {
                return Redirect("/Unauthorized");
            }
            Product = _context.Products
                .Include(p => p.Category)
                .Include(p => p.Supplier).ToList();
            return Page();
        }

        public IActionResult OnPostSearchNameOrId(string keyword)
        {
            if (!_authorized)
            {
                return Redirect("/Unauthorized");
            }
            Product = _context.Products
                .Include(p => p.Category)
                .Include(p => p.Supplier)
                .Where(p => p.ProductName.ToLower().Contains(keyword.ToLower()) || (keyword.All(char.IsDigit) ? p.ProductId == int.Parse(keyword) : false))
                .ToList();
            return Page();
        }

        public IActionResult OnPostSearchRange(decimal fromPrice, decimal toPrice)
        {
            if (!_authorized)
            {
                return Redirect("/Unauthorized");
            }
            if (fromPrice > toPrice)
            {
                TempData["Message"] = "Range is not valid!";
                return Redirect("/ProductManagement/Index");
            }
            Product = _context.Products
                .Include(p => p.Category)
                .Include(p => p.Supplier)
                .Where(p => p.UnitPrice >= fromPrice && p.UnitPrice <= toPrice)
                .ToList();
            return Page();
        }
    }
}
