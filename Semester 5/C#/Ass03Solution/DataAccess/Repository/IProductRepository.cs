using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
        Product GetProductByID(int productId);
        //Product GetProductByName(string productName);
        void InsertProduct(Product product);
        void DeleteProduct(int productId);
        void UpdateProduct(Product product);
        IEnumerable<Product> GetProductsByName(string name);
        IEnumerable<Product> SortByName();
        IEnumerable<Product> GetProductsByUnitPrice(int unitPrice);
        IEnumerable<Product> GetProductsByUnitsInStock(int unitsInStock);
        IEnumerable<Product> GetProductsById(int productId);
        IEnumerable<Product> SearchProductsInPriceRange(decimal from, decimal to);
    }
}
