using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace PizzaShopWebApplication.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }
        [Required(ErrorMessage = "Customer ID is required")]
        [Display(Name = "ID")]
        public string CustomerId { get; set; }

        [RegularExpression(@"^.{6,}$", ErrorMessage = "Minimum 6 characters required")]
        [Required(ErrorMessage = "Password is required")]
        [Display(Name = "Password")]
        [StringLength(30, MinimumLength = 6, ErrorMessage = "Password must be between 6 and 30 characters!")]
        public string Password { get; set; }
        public string ContactName { get; set; }
        public string Address { get; set; }
        [Phone(ErrorMessage = "Phone number is not valid!")]
        public string Phone { get; set; }
        [EmailAddress(ErrorMessage = "Email is not valid!")]
        public string Email { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
