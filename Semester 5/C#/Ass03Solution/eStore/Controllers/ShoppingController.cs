using BusinessObject;
using DataAccess.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eStore.Controllers
{
    public class ShoppingController : Controller
    {
        IProductRepository productRepo = null;

        public ShoppingController() => productRepo = new ProductRepository();
        public bool permission
        {
            get
            {
                IHttpContextAccessor _httpContextAccessor = new HttpContextAccessor();
                string role = _httpContextAccessor.HttpContext.Session.GetString("LOGIN_USER");
                if (role == null)
                {
                    return false;
                }
                else
                {
                    if (role.StartsWith("MEMBER"))
                    {
                        return true;
                    }
                    return false;
                }

            }
        }
        // GET: ShoppingController
        public ActionResult Index()
        {
            if (permission)
            {
                ViewBag.Message = TempData["Message"];
                var productList = productRepo.GetProducts();
                return View(productList);
            }
            else
            {
                TempData["Message"] = "You are not a member!!!";
                return RedirectToAction("LoginPage", "Home");
            }

        }
        public ActionResult RemoveCart()
        {
            if (permission)
            {
                try
                {
                    string id1 = HttpContext.Request.Query["id1"];
                    var product = productRepo.GetProductByID(Int32.Parse(id1));

                    IHttpContextAccessor _httpContextAccessor = new HttpContextAccessor();
                    Cart cart = _httpContextAccessor.HttpContext.Session.GetObject<Cart>("CART");
                    ICartRepository cartRepo = new CartRepository();
                    Cart tmp = cart;
                    cartRepo.RemoveFromCart(ref tmp, product.ProductId);
                    cart = tmp;
                    HttpContext.Session.SetObject("CART", cart);
                    TempData["Message"] = "Remove successfully!";
                    return RedirectToAction("Cart");
                }
                catch (Exception ex)
                {
                    TempData["Message"] = "Error: " + ex.Message;
                    return RedirectToAction("Cart");
                }
                
            }
            else
            {
                TempData["Message"] = "You are not a member!!!";
                return RedirectToAction("LoginPage", "Home");
            }
            
        }
        public ActionResult UpdateCart()
        {
            if (permission)
            {
                try
                {
                    string id1 = HttpContext.Request.Query["id1"];
                    string quantity1 = HttpContext.Request.Query["quantity1"];
                    var product = productRepo.GetProductByID(Int32.Parse(id1));
                    if (Int32.Parse(quantity1) > product.UnitsInStock)
                    {
                        TempData["Message"] = "Your ordered product's quantity exceed Units in stock!";
                        return RedirectToAction("Cart");
                    }

                    IHttpContextAccessor _httpContextAccessor = new HttpContextAccessor();
                    Cart cart = _httpContextAccessor.HttpContext.Session.GetObject<Cart>("CART");
                    ICartRepository cartRepo = new CartRepository();
                    Cart tmp = cart;
                    cartRepo.UpdateCart(ref tmp, product.ProductId, Int32.Parse(quantity1));
                    cart = tmp;
                    HttpContext.Session.SetObject("CART", cart);
                    TempData["Message"] = "Update successfully!";
                    return RedirectToAction("Cart");
                }
                catch(Exception ex)
                {
                    TempData["Message"] = "Error: "+ex.Message;
                    return RedirectToAction("Cart");
                }
                
            }
            else
            {
                TempData["Message"] = "You are not a member!!!";
                return RedirectToAction("LoginPage", "Home");
            }

        }
        public ActionResult AddToCart()
        {
            if (permission)
            {
                try
                {
                    string quantity1 = HttpContext.Request.Query["quantity1"];
                    string id1 = HttpContext.Request.Query["id1"];
                    int quantity = Int32.Parse(quantity1);
                    int id = Int32.Parse(id1);
                    IMemberRepository memberRepo = new MemberRepository();
                    ICartRepository cartRepo = new CartRepository();

                    IHttpContextAccessor _httpContextAccessor = new HttpContextAccessor();
                    Cart cart = _httpContextAccessor.HttpContext.Session.GetObject<Cart>("CART");
                    string role = _httpContextAccessor.HttpContext.Session.GetString("LOGIN_USER");

                    var product = productRepo.GetProductByID(id);
                    if (quantity > product.UnitsInStock)
                    {
                        TempData["Message"] = "Your ordered product's quantity exceed Units In Stock!";
                        return RedirectToAction(nameof(Index));
                    }
                    Cart tmp = cart;
                    if (tmp == null)
                    {
                        tmp = new Cart
                        {
                            MemberId = memberRepo.GetMemberByEmail(role.Substring(8)).MemberId
                        };
                    }
                    cartRepo.AddToCart(ref tmp, product.ProductId, quantity);
                    cart = tmp;
                    HttpContext.Session.SetObject("CART", cart);
                    TempData["Message"] = "Add successfully!";
                    return RedirectToAction(nameof(Index));
           
                    
                }
                catch(Exception ex)
                {
                    TempData["Message"] = "Something went wrong!! Error: " + ex.Message;
                    return RedirectToAction(nameof(Index));
                }
            }
            else
            {
                TempData["Message"] = "You are not a member!!!";
                return RedirectToAction("LoginPage", "Home");
            }
            
        }

        public ActionResult Cart()
        {
            if (permission)
            {
                try
                {
                    IHttpContextAccessor _httpContextAccessor = new HttpContextAccessor();
                    Cart cart = _httpContextAccessor.HttpContext.Session.GetObject<Cart>("CART");
                    ViewBag.Message = TempData["Message"];
                    if (cart != null)
                    {
                        var cartList = cart.ListProduct;
                        return View(cartList);
                    }
                    else
                    {
                        TempData["Message"] = "Cart is null!!";
                        return RedirectToAction(nameof(Index));
                    }
                }
                catch (Exception ex)
                {
                    TempData["Message"] = "Something went wrong!! Error: " + ex.Message;
                    return RedirectToAction(nameof(Index));
                }
            }
            else
            {
                TempData["Message"] = "You are not a member!!!";
                return RedirectToAction("LoginPage", "Home");
            }
        }
        public ActionResult Checkout()
        {
            if (permission)
            {
                try
                {
                    IMemberRepository memberRepo = new MemberRepository();
                    ICartRepository cartRepo = new CartRepository();
                    IOrderRepository orderRepo = new OrderRepository();
                    IOrderDetailRepository orderDetailRepo = new OrderDetailRepository();

                    IHttpContextAccessor _httpContextAccessor = new HttpContextAccessor();
                    Cart cart = _httpContextAccessor.HttpContext.Session.GetObject<Cart>("CART");
                    string role = _httpContextAccessor.HttpContext.Session.GetString("LOGIN_USER");

                    if (cart == null || cart.ListProduct.Count == 0)
                    {
                        TempData["Message"] = "Your cart is empty!";
                        return RedirectToAction(nameof(Index));
                    }
                    bool check = true;
                    foreach (var productInCart in cart.ListProduct)
                    {
                        var productInStore = productRepo.GetProductByID(productInCart.ProductId);
                        if (productInCart.Quantity > productInStore.UnitsInStock)
                        {
                            check = false;
                            break;
                        }
                    }
                    if (check == true)
                    {
                        Order order = new Order
                        {
                            OrderId = 0,
                            OrderDate = DateTime.Now,
                            MemberId = memberRepo.GetMemberByEmail(role.Substring(8)).MemberId,
                            RequiredDate = DateTime.Now.AddDays(5),
                            ShippedDate = DateTime.Now.AddDays(5),
                            Freight = 0
                        };
                        orderRepo.InsertOrder(order);
                        foreach (var productInCart in cart.ListProduct)
                        {
                            var productInStore = productRepo.GetProductByID(productInCart.ProductId);
                            productInStore.UnitsInStock = productInStore.UnitsInStock - productInCart.Quantity;
                            productRepo.UpdateProduct(productInStore);

                            IEnumerable<Order> listOrder = orderRepo.GetOrdersByMemebrId(memberRepo.GetMemberByEmail(role.Substring(8)).MemberId);
                            int currentId = listOrder.Max(ord => ord.OrderId);

                            OrderDetail currentDetail = new OrderDetail
                            {
                                OrderId = currentId,
                                ProductId = productInCart.ProductId,
                                UnitPrice = productInStore.UnitPrice,
                                Quantity = productInCart.Quantity,
                                Discount = 0
                            };
                            orderDetailRepo.AddDetail(currentDetail);
                        }
                        Cart tmp = cart;
                        cartRepo.DeleteCart(ref tmp);
                        cart = tmp;
                        HttpContext.Session.SetObject("CART", cart);
                        TempData["Message"] = "Checkout successfully!";
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        TempData["Message"] = "Your ordered quantity exceeds quantity in stock!!!";
                        return RedirectToAction("Cart"); 
                    }

                }
                catch (Exception ex)
                {
                    TempData["Message"] = "Something went wrong!! Error: " + ex.Message;
                    return RedirectToAction(nameof(Index));
                }
            }
            else
            {
                TempData["Message"] = "You are not a member!!!";
                return RedirectToAction("LoginPage", "Home");
            }
                
        }
    }
    
    public static class SessionExtensions
    {
        public static void SetObject(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T GetObject<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
}
