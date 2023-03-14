using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PizzaShopWebApplication.Models;
using PizzaShopWebApplication.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaShopWebApplication.Pages.OrderManagement.CartPage
{
    public class ViewCartModel : PageModel
    {
        private readonly PizzaShopWebApplication.Models.NorthwindCopyDBContext _context;
        public ViewCartModel(PizzaShopWebApplication.Models.NorthwindCopyDBContext context)
        {
            _context = context;
        }

        public Cart Cart
        {
            get
            {
                return CartUtils.Cart;
            }
        }
        public Customer Customer { get; set; }
        public bool _authorized
        {
            get
            {
                return CustomAuthorization.CheckRole("ADMIN");
            }
        }
        public List<ProductInCart> ListProduct { get; set; }
        public IActionResult OnGet()
        {
            ListProduct = Cart.ListProduct;
            if(!_authorized)
            {
                return Redirect("/Unauthorized");
            }
            if (Cart == null)
            {
                TempData["Message"] = "Cart is not found!!";
                return Redirect("/OrderManagement/CartPage/AddToCart");
            }
            Customer = _context.Customers.FirstOrDefault(c => c.CustomerId == Cart.CustomerId);
            return Page();
        }

        public IActionResult OnPostUpdateQuantity(int id, int quantity)
        {
            if (!_authorized)
            {
                return Redirect("/Unauthorized");
            }
            if (Cart == null)
            {
                TempData["Message"] = "Cart is not found!!";
                return Redirect("/OrderManagement/CartPage/ViewCart");
            }
            try
            {
                var product = _context.Products.FirstOrDefault(p => p.ProductId == id);
                if (quantity > product.QuantityPerUnit)
                {
                    TempData["Message"] = "Quantity exceed Units In Stock!";
                    return Redirect("/OrderManagement/CartPage/ViewCart");
                }
                UpdateCart(product.ProductId, quantity);
                TempData["Message"] = "Update successfully!";
                return Redirect("/OrderManagement/CartPage/ViewCart");
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Something went wrong!! Error: " + ex.Message;
                return Redirect("/OrderManagement/CartPage/ViewCart");
            }
        }

        public IActionResult OnPostRemoveFromCart(int id)
        {
            if (!_authorized)
            {
                return Redirect("/Unauthorized");
            }
            if (Cart == null)
            {
                TempData["Message"] = "Cart is not found!!";
                return Redirect("/OrderManagement/CartPage/ViewCart");
            }
            try
            {
                var product = _context.Products.FirstOrDefault(p => p.ProductId == id);
                
                RemoveFromCart(product.ProductId);
                TempData["Message"] = "Remove successfully!";
                return Redirect("/OrderManagement/CartPage/ViewCart");
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Something went wrong!! Error: " + ex.Message;
                return Redirect("/OrderManagement/CartPage/ViewCart");
            }
        }

        public IActionResult OnGetConfirmOrder()
        {
            if (!_authorized)
            {
                return Redirect("/Unauthorized");
            }
            try
            {
                using var transaction = _context.Database.BeginTransaction();
                Customer = _context.Customers.FirstOrDefault(c => c.CustomerId == Cart.CustomerId);
                if (Cart == null || Cart.ListProduct.Count == 0)
                {
                    TempData["Message"] = "Your cart is empty!";
                    return Redirect("/OrderManagement/CartPage/AddToCart");
                }
                bool check = true;
                foreach (var productInCart in Cart.ListProduct)
                {
                    var productInStore = _context.Products.FirstOrDefault(p => p.ProductId == productInCart.ProductId);
                    if (productInCart.Quantity > productInStore.QuantityPerUnit)
                    {
                        check = false;
                        break;
                    }
                }
                if (check == true)
                {
                    Guid g = Guid.NewGuid();
                    Order order = new Order
                    {
                        OrderId = g.ToString().Substring(6),
                        OrderDate = DateTime.Now,
                        CustomerId = Customer.CustomerId,
                        RequiredDate = DateTime.Now.AddDays(5),
                        ShippedDate = DateTime.Now.AddDays(5),
                        Freight = 10,
                        ShipAddress = Customer.Address,
                    };
                    _context.Orders.Add(order);
                    foreach (var productInCart in Cart.ListProduct)
                    {
                        var productInStore = _context.Products.FirstOrDefault(p => p.ProductId == productInCart.ProductId);
                        productInStore.QuantityPerUnit = productInStore.QuantityPerUnit - productInCart.Quantity;
                        _context.Products.Update(productInStore);

                        OrderDetail currentDetail = new OrderDetail
                        {
                            OrderId = order.OrderId,
                            ProductId = productInCart.ProductId,
                            UnitPrice = productInStore.UnitPrice ?? 0,
                            Quantity = (short)productInCart.Quantity,
                        };
                        _context.OrderDetails.Add(currentDetail);
                    }
                    _context.SaveChanges();
                    transaction.Commit();
                    CartUtils.DeleteCartInSession();
                    TempData["Message"] = "Checkout successfully!";
                    return Redirect("/OrderManagement/Orders/Index");
                }
                else
                {
                    TempData["Message"] = "Your ordered quantity exceeds quantity in stock!!!";
                    return Redirect("/OrderManagement/CartPage/ViewCart");
                }
               
            }
                catch (Exception ex)
                {
                    TempData["Message"] = "Something went wrong!! Error: " + ex.Message;
                    return Redirect("/OrderManagement/CartPage/ViewCart");
            }

        }

        public void UpdateCart(int productId, int quantity)
        {
            if (Cart != null)
            {
                if (Cart.ListProduct != null && Cart.ListProduct.Count != 0)
                {
                    int i = 0;
                    while (i < Cart.ListProduct.Count)
                    {
                        var product = Cart.ListProduct[i];
                        if (productId == product.ProductId)
                        {
                            product = new ProductInCart
                            {
                                ProductId = productId,
                                ProductName = product.ProductName,
                                Quantity = quantity,
                                UnitPrice = product.UnitPrice,
                                TotalPrice = quantity * product.UnitPrice
                            };
                            Cart tempCart = Cart;
                            tempCart.ListProduct[i] = product;
                            CartUtils.SetCartInSession(tempCart);
                            UpdateTotalPrice();
                            return;
                        }
                        i++;
                    }
                    throw new Exception("Product in cart not found!");
                }
                throw new Exception("List product not found!");
            }
            throw new Exception("Cart not found!");
        }

        public void UpdateTotalPrice()
        {
            decimal totalPrice = 0;
            foreach (var pro in Cart.ListProduct)
            {
                totalPrice += pro.TotalPrice;
            }
            Cart tmp = Cart;
            tmp.TotalPrice = totalPrice;
            CartUtils.SetCartInSession(tmp);
        }
        public void RemoveFromCart(int productId)
        {
            if (Cart != null)
            {
                bool check = false;
                if (Cart.ListProduct != null && Cart.ListProduct.Count != 0)
                {
                    int i = 0;
                    while (check == false && i < Cart.ListProduct.Count)
                    {
                        var product = Cart.ListProduct[i];
                        if (productId == product.ProductId)
                        {
                            Cart tmp = Cart;
                            tmp.ListProduct.RemoveAt(i);
                            CartUtils.SetCartInSession(tmp);
                            UpdateTotalPrice();
                            return;
                        }
                        i++;
                    }
                    throw new Exception("Product in cart not found!");
                }
                throw new Exception("List product not found!");
            }
            throw new Exception("Cart not found!");
        }

    }
}
