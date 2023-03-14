using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaShopWebApplication.Models
{
    public class Cart
    {
        public List<ProductInCart> ListProduct { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal Freight { get; set; }
        public string CustomerId { get; set; }
        public Cart() { }
    }
}