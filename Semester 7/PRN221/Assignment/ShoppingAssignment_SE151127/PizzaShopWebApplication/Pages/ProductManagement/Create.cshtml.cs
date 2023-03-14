using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PizzaShopWebApplication.Models;
using PizzaShopWebApplication.Utils;

namespace PizzaShopWebApplication.Pages.ProductManagement
{
    public class CreateModel : PageModel
    {
        private readonly PizzaShopWebApplication.Models.NorthwindCopyDBContext _context;
        private IHostingEnvironment _environment;

        public bool _authorized
        {
            get
            {
                return CustomAuthorization.CheckRole("ADMIN");
            }
        }
        [Required(ErrorMessage = "Please choose 1 file")]
        [DataType(DataType.Upload)]
        [FileExtensions(Extensions = "png,jpg,gif,jpeg")]
        [Display(Name = "Choose file to upload")]
        [BindProperty]
        public IFormFile[] FileUploads { get; set; }
        public CreateModel(PizzaShopWebApplication.Models.NorthwindCopyDBContext context, IHostingEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public IActionResult OnGet()
        {
            if (!_authorized)
            {
                return Redirect("/Unauthorized");
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName");
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "SupplierId", "CompanyName");
            return Page();
        }

        [BindProperty]
        public Product Product { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!_authorized)
            {
                return Redirect("/Unauthorized");
            }
            if (FileUploads != null)
            {
                foreach (var FileUpload in FileUploads)
                {
                    var file = Path.Combine(_environment.WebRootPath, "Images", FileUpload.FileName);
                    using (var fileStream = new FileStream(file, FileMode.Create))
                    {
                        Product.ProductImage = FileUpload.FileName;
                        await FileUpload.CopyToAsync(fileStream);
                    }
                }
            }
            Product pro = _context.Products.FirstOrDefault(e => e.ProductId == Product.ProductId);
            if (pro != null)
            {
                ViewData["ErrorMessage"] = "ProductId is duplicated!!! Try again!";
                return Page();
            }
            _context.Products.Add(Product);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
