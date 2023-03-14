using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PizzaShopWebApplication.Models;
using PizzaShopWebApplication.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace PizzaShopWebApplication.Pages.OrderManagement.CartPage
{
    public class AddToCartModel : PageModel
    {
        private readonly PizzaShopWebApplication.Models.NorthwindCopyDBContext _context;
        public bool _authorized
        {
            get
            {
                return CustomAuthorization.CheckRole("ADMIN");
            }
        }

        public SelectList Customer { get; set; }

        public AddToCartModel(PizzaShopWebApplication.Models.NorthwindCopyDBContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get; set; }

        public Cart Cart {
            get
            {
                return CartUtils.Cart;
            }
        }

        public IActionResult OnGet()
        {
            if (!_authorized)
            {
                return Redirect("/Unauthorized");
            }
            Product = _context.Products
                .Include(p => p.Category)
                .Include(p => p.Supplier).ToList();
            Customer = new SelectList(_context.Customers, "CustomerId", "Email");
            return Page();
        }
        public IActionResult OnPostSetCustomer(string customerId, string customerEmail)
        {
            if (!_authorized)
            {
                return Redirect("/Unauthorized");
            }
            try
            {
                Customer cus = _context.Customers.FirstOrDefault(c => c.CustomerId == customerId && c.Email.ToLower() == customerEmail.ToLower());
                if (cus == null)
                {
                    TempData["Message"] = "Something went wrong! Customer not found!";
                    return Redirect("/OrderManagement/CartPage/AddToCart");
                }
                if (Cart == null)
                {
                    CartUtils.SetCartInSession(new Cart() { CustomerId = customerId, ListProduct = new List<ProductInCart>() });
                }
                else
                {
                    Cart tmp = Cart;
                    tmp.CustomerId = customerId;
                    CartUtils.SetCartInSession(tmp);
                }
                TempData["Message"] = "Set customer email " + customerEmail + " successfully!";
                return Redirect("/OrderManagement/CartPage/AddToCart");
            }
            catch
            {
                TempData["Message"] = "please choose a customer!!!";
                return Redirect("/OrderManagement/CartPage/AddToCart");
            }
        }
        public IActionResult OnPost(int id, int quantity)
        {
            if (!_authorized)
            {
                return Redirect("/Unauthorized");
            }
            try
            {
                string role = CustomAuthorization.Role();

                var product = _context.Products.FirstOrDefault(p => p.ProductId == id);
                if (quantity > product.QuantityPerUnit)
                {
                    TempData["Message"] = "Your ordered product's quantity exceed Units In Stock!";
                    return Page();
                }
                if (Cart == null)
                {
                    CartUtils.SetCartInSession(new Cart() { ListProduct = new List<ProductInCart>() });
                    AddToCart(product.ProductId, quantity);
                }
                else
                {
                    AddToCart(product.ProductId, quantity);
                }
                TempData["Message"] = "Add successfully!";
                return Redirect("/OrderManagement/CartPage/AddToCart");
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Something went wrong!! Error: " + ex.Message;
                return Redirect("/OrderManagement/CartPage/AddToCart");
            }
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

        public void AddToCart(int productId, int quantity)
        {
            try
            {
                bool update = false;
                if (Cart.ListProduct.Count != 0)
                {
                    int i = 0;
                    while (update == false && i < Cart.ListProduct.Count)
                    {
                        var product = Cart.ListProduct[i];
                        if (productId == product.ProductId)
                        {
                            product.Quantity += quantity;
                            product.TotalPrice = product.Quantity * product.UnitPrice;
                            update = true;
                            Cart tempCart = Cart;
                            tempCart.ListProduct[i] = product;
                            CartUtils.SetCartInSession(tempCart);
                            UpdateTotalPrice();
                        }
                        i++;
                    }
                }
                if (update == false)
                {
                    Product product = _context.Products.FirstOrDefault(p => p.ProductId == productId);
                    ProductInCart pro = new ProductInCart
                    {
                        ProductId = productId,
                        ProductName = product.ProductName,
                        Quantity = quantity,
                        UnitPrice = product.UnitPrice ?? 0,
                        TotalPrice = quantity * (product.UnitPrice ?? 0)
                    };
                    Cart tempCart = Cart;
                    tempCart.ListProduct.Add(pro);
                    CartUtils.SetCartInSession(tempCart);
                    UpdateTotalPrice();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
