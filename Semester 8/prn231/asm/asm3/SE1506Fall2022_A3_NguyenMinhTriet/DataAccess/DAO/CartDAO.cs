using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    class CartDAO
    {
        //Using Singleton Pattern
        private static CartDAO instance = null;
        private static readonly object instanceLock = new object();
        private CartDAO() { }
        public static CartDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new CartDAO();
                    }
                    return instance;
                }
            }
        }
        public Cart AddToCart(ref Cart cart, int productId, int quantity)
        {
            try
            {
                using var context = new eStoreDbContext();
                Product pro = context.Products.SingleOrDefault(p => p.ProductId == productId);
                if (pro.UnitsInStock < quantity)
                {
                    throw new Exception("Your ordered product's quantity exceed Units In Stock!");
                }
                if (cart == null)
                {
                    cart = new Cart();
                }
                if (cart.ListProduct == null)
                {
                    cart.ListProduct = new List<ProductInCart>();
                }
                bool update = false;
                if (cart.ListProduct.Count != 0)
                {
                    int i = 0;
                    while (update == false && i < cart.ListProduct.Count)
                    {
                        var product = cart.ListProduct[i];
                        if (productId == product.ProductId)
                        {
                            product.Quantity += quantity;
                            product.TotalPrice = product.Quantity * product.UnitPrice;
                            update = true;
                            UpdateTotalPrice(ref cart);
                        }
                        i++;
                    }
                }
                if (update == false)
                {
                    var product = context.Products.SingleOrDefault(p => p.ProductId == productId);
                    cart.ListProduct.Add(new ProductInCart
                    {
                        ProductId = productId,
                        ProductName = product.ProductName,
                        Quantity = quantity,
                        UnitPrice = product.UnitPrice,
                        TotalPrice = quantity * product.UnitPrice
                    });
                    UpdateTotalPrice(ref cart);
                }
                return cart;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public Cart RemoveFromCart(ref Cart cart, int productId)
        {
            if (cart != null)
            {
                bool check = false;
                if (cart.ListProduct != null && cart.ListProduct.Count != 0)
                {
                    int i = 0;
                    while (check == false && i < cart.ListProduct.Count)
                    {
                        var product = cart.ListProduct[i];
                        if (productId == product.ProductId)
                        {
                            cart.ListProduct.Remove(product);
                            UpdateTotalPrice(ref cart);
                            return cart;
                        }
                        i++;
                    }
                    throw new Exception("Product in cart not found!");
                }
                throw new Exception("List product not found!");
            }
            throw new Exception("Cart not found!");
        }
        public Cart UpdateCart(ref Cart cart, int productId, int quantity)
        {
            using var context = new eStoreDbContext();

            Product pro = context.Products.SingleOrDefault(p => p.ProductId == productId);
            if (pro.UnitsInStock < quantity)
            {
                throw new Exception("Your ordered product's quantity exceed Units In Stock!");
            }
            if (cart != null)
            {
                if (cart.ListProduct != null && cart.ListProduct.Count != 0)
                {
                    int i = 0;
                    while (i < cart.ListProduct.Count)
                    {
                        var product = cart.ListProduct[i];
                        if (productId == product.ProductId)
                        {
                            cart.ListProduct[i] = new ProductInCart
                            {
                                ProductId = productId,
                                ProductName = product.ProductName,
                                Quantity = quantity,
                                UnitPrice = product.UnitPrice,
                                TotalPrice = quantity * product.UnitPrice
                            };
                            UpdateTotalPrice(ref cart);
                            return cart;
                        }
                        i++;
                    }
                    throw new Exception("Product in cart not found!");
                }
                throw new Exception("List product not found!");
            }
            throw new Exception("Cart not found!");
        }

        public void DeleteCart(ref Cart cart)
        {
            cart = null;
        }
        public void SetFreight(ref Cart cart, decimal freight)
        {
            cart.Freight = freight;
        }
        public void UpdateTotalPrice(ref Cart cart)
        {
            decimal totalPrice = 0;
            foreach (var pro in cart.ListProduct)
            {
                totalPrice += pro.TotalPrice;
            }
            cart.TotalPrice = totalPrice;
        }
    }
}
