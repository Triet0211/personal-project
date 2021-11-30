using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class Cart
    {
        public List<ProductInCart> ListProduct { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal Freight { get; set; }
        public int MemberId { get; set; }
        public Cart() { }
    }
}
