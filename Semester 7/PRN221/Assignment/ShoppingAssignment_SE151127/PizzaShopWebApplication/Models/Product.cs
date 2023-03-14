using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace PizzaShopWebApplication.Models
{
    public partial class Product
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int ProductId { get; set; }
        [Required(ErrorMessage = "Required")]
        public string ProductName { get; set; }
        [DisplayName("Supplier")]
        public int? SupplierId { get; set; }
        [DisplayName("Category")]
        public int? CategoryId { get; set; }

        [Range(0, int.MaxValue)]
        [Required(ErrorMessage = "Required")]
        public int? QuantityPerUnit { get; set; }

        [Range(0, int.MaxValue)]
        [Required(ErrorMessage = "Required")]
        public decimal? UnitPrice { get; set; }
        public string ProductImage { get; set; }
        public byte? ProductStatus { get; set; }

        public virtual Category Category { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
