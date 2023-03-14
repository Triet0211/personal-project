using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using PizzaShopWebApplication.Models;
using System.IO;
using System.Linq;
using Utils;

namespace PizzaShopWebApplication.Pages.Login
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public string Msg { get; set; }

        private readonly NorthwindCopyDBContext _context;

        public LoginModel(NorthwindCopyDBContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            var configurationBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configurationBuilder.AddJsonFile(path, true, true);
            var root = configurationBuilder.Build();
            string emailJson = root.GetSection("AdministratorAccount").GetSection("Email").Value;
            string passwordJson = root.GetSection("AdministratorAccount").GetSection("Password").Value;
            if (Email.Equals(emailJson) && Password.Equals(passwordJson))
            {
                HttpContext.Session.SetString("LoginUser", JsonUtils.SerializeComplexData(new LoginUser()
                {
                    Id = null,
                    Email = emailJson,
                    Role = "ADMIN"
                }));
                Msg = "Success";
                return RedirectToPage("/Index");
            }
            else
            {
                Customer cus = _context.Customers.FirstOrDefault(cus => cus.Email.ToLower().Equals(Email.ToLower()) && cus.Password == Password);
                if (cus != null)
                {
                    HttpContext.Session.SetString("LoginUser", JsonUtils.SerializeComplexData(new LoginUser()
                    {
                        Id = cus.CustomerId,
                        Email = Email,
                        Role = "CUSTOMER"
                    }));
                    Msg = "Success";
                    return RedirectToPage("/Index");
                }
                else
                {
                    Msg = "Invalid";
                    return Page();
                }
            }
           
        }
        public IActionResult OnGetLogout()
        {
            HttpContext.Session.Clear();
            return RedirectToPage("/Index");
        }
    }
}
