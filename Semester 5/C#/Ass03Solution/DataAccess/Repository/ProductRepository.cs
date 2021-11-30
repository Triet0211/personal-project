using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class ProductRepository : IProductRepository
    {
        public IEnumerable<Product> GetProducts() => ProductDAO.Instance.GetProductList();
        public Product GetProductByID(int productId) => ProductDAO.Instance.GetProductByID(productId);
        //public Product GetProductByName(string productName) => ProductDAO.Instance.GetProductByName(productName);
        public void InsertProduct(Product product) => ProductDAO.Instance.AddNewProduct(product);
        public void DeleteProduct(int productId) => ProductDAO.Instance.Remove(productId);
        public void UpdateProduct(Product product) => ProductDAO.Instance.UpdateProduct(product);
        public IEnumerable<Product> GetProductsByName(string name) => ProductDAO.Instance.SearchProductsByName(name);
        public IEnumerable<Product> SortByName() => ProductDAO.Instance.SortByName;
        public IEnumerable<Product> GetProductsByUnitPrice(int unitPrice) => ProductDAO.Instance.SearchProductsByUnitPrice(unitPrice);
        public IEnumerable<Product> GetProductsByUnitsInStock(int unitsInStock) => ProductDAO.Instance.SearchProductsByUnitsInStock(unitsInStock);
        public IEnumerable<Product> GetProductsById(int productId) => ProductDAO.Instance.SearchProductsById(productId);
        public IEnumerable<Product> SearchProductsInPriceRange(decimal from, decimal to) => ProductDAO.Instance.SearchProductsInPriceRange(from, to);
    }
}
