using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    class ProductDAO
    {
        //Using Singleton Pattern
        private static ProductDAO instance = null;
        private static readonly object instanceLock = new object();
        private ProductDAO() { }
        public static ProductDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ProductDAO();
                    }
                    return instance;
                }
            }
        }
        public IEnumerable<Product> GetProductList()
        {
            
            var products = new List<Product>();
            try
            {
                using var context = new MyFStoreContext();
                products = context.Products.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return products;
        }
        public Product GetProductByID(int productId)
        {
            Product product = null;
            try
            {
                using var context = new MyFStoreContext();
                product = context.Products.SingleOrDefault(p => p.ProductId == productId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return product;
        }
        //public Product GetProductByName(string productName)
        //{
        //    Product product = null;
        //    try
        //    {
               

        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //    return product;
        //}
        public void AddNewProduct(Product product)
        {
            try
            {
                Product pro = GetProductByID(product.ProductId);
                if(pro == null)
                {
                    using var context = new MyFStoreContext();
                    context.Products.Add(product);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("This product Id is existed!");
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void UpdateProduct(Product product)
        {
            try
            {
                Product pro = GetProductByID(product.ProductId);
                if (pro != null)
                {
                    using var context = new MyFStoreContext();
                    context.Products.Update(product);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("This product is not found!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Remove(int productId)
        {
            try
            {
                Product pro = GetProductByID(productId);
                if (pro != null)
                {
                    using var context = new MyFStoreContext();
                    context.Products.Remove(pro);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("This product is not existed!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public IEnumerable<Product> SearchProductsByName(string productName)
        {
            var products = new List<Product>();
            try
            {
                using var context = new MyFStoreContext();
                products = context.Products.Where(p => p.ProductName.Contains(productName)).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return products;
        }
        public IEnumerable<Product> SearchProductsById(int productId)
        {
            var products = new List<Product>();
            try
            {
                using var context = new MyFStoreContext();
                products = context.Products.Where(p => p.ProductId == productId).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return products;
        }
        public IEnumerable<Product> SearchProductsByUnitPrice(int unitPrice)
        {
            var products = new List<Product>();
            try
            {
                using var context = new MyFStoreContext();
                products = context.Products.Where(p => p.UnitPrice == unitPrice).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return products;
        }
        public IEnumerable<Product> SearchProductsByUnitsInStock(int unitsInStock)
        {
            var products = new List<Product>();
            try
            {
                using var context = new MyFStoreContext();
                products = context.Products.Where(p => p.UnitsInStock == unitsInStock).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return products;
        }
        public IEnumerable<Product> SearchProductsInPriceRange(decimal from, decimal to)
        {
            var products = new List<Product>();
            try
            {
                using var context = new MyFStoreContext();
                products = context.Products.Where(p => p.UnitPrice >= from && p.UnitPrice <= to).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return products;
        }
        public IEnumerable<Product> SortByName => GetProductList().ToList().OrderBy(pro => pro.ProductName);
    }
}
