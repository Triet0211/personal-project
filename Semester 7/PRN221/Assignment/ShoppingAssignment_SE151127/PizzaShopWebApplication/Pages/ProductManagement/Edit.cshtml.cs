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
using Microsoft.EntityFrameworkCore;
using PizzaShopWebApplication.Models;
using PizzaShopWebApplication.Utils;

namespace PizzaShopWebApplication.Pages.ProductManagement
{
    public class EditModel : PageModel
    {
        private readonly PizzaShopWebApplication.Models.NorthwindCopyDBContext _context;
        public bool _authorized
        {
            get
            {
                return CustomAuthorization.CheckRole("ADMIN");
            }
        }
        [DataType(DataType.Upload)]
        [FileExtensions(Extensions = "png,jpg,gif,jpeg")]
        [Display(Name = "Choose file to upload")]
        [BindProperty]
        public IFormFile[] FileUploads { get; set; }
        [BindProperty]
        public string OldImageName { get; set; }
        private IHostingEnvironment _environment;

        public EditModel(PizzaShopWebApplication.Models.NorthwindCopyDBContext context, IHostingEnvironment environment)
        {
            _environment = environment;
            _context = context;
        }

        [BindProperty]
        public Product Product { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (!_authorized)
            {
                return Redirect("/Unauthorized");
            }
            if (id == null)
            {
                return NotFound();
            }

            Product = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Supplier).FirstOrDefaultAsync(m => m.ProductId == id);

            if (Product == null)
            {
                return NotFound();
            }
           ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName");
           ViewData["SupplierId"] = new SelectList(_context.Suppliers, "SupplierId", "CompanyName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
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
                if (FileUploads.Length == 0)
                {
                    Product.ProductImage = OldImageName;
                    _context.Products.Update(Product);
                }

            }

            //_context.Attach(Product).State = EntityState.Modified;
            _context.Products.Update(Product);
            
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(Product.ProductId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ProductId == id);
        }
    }
}
