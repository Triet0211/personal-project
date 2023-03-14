using BusinessObject;
using eStore.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using Utils;

namespace eStore.Controllers
{
    [Authorize]
    public class ShoppingController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly HttpClient client = null;
        public LoginUser loginUser { get; }
        private readonly UserManager<eStoreUser> _userManager;
        public bool permission { get; }
        public ShoppingController(IHttpContextAccessor httpContextAccessor, UserManager<eStoreUser> userManager)
        {
            _httpContextAccessor = httpContextAccessor;
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            _userManager = userManager;
            loginUser = new LoginUser()
            {
                Email = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Email),
                Id = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier),
                Role = _httpContextAccessor.HttpContext.User.IsInRole("Administrator") ? "ADMIN" : "MEMBER"
            };
            permission = _httpContextAccessor.HttpContext.User.IsInRole("Administrator") || _httpContextAccessor.HttpContext.User.IsInRole("Member");
        }
        // GET: ShoppingController
        public async Task<IActionResult> Index()
        {
            try
            {
                if (permission)
                {
                    ViewBag.Message = TempData["Message"];
                    string GetProductUrl = "http://localhost:34845/api/Products";
                    HttpResponseMessage response = await client.GetAsync(GetProductUrl);
                    string strData = await response.Content.ReadAsStringAsync();
                    ResponseUtils.CheckResponseIsSuccess(response, strData);
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true,
                    };
                    List<Product> listProducts = JsonSerializer.Deserialize<List<Product>>(strData, options);

                    return View(listProducts);
                }
                else
                {
                    TempData["Message"] = "You are not an admin!!!";
                    return RedirectToAction("LoginPage", "Home");
                }
            } catch (Exception e)
            {
                TempData["Message"] = e.Message;
                return RedirectToAction("Index", "Home");
            }
            

        }
        public async Task<IActionResult> RemoveCart()
        {
            if (permission)
            {
                try
                {
                    string id1 = HttpContext.Request.Query["id1"];

                    string RemoveProductUrl = "http://localhost:34845/api/Shopping/remove/" + Int32.Parse(id1);
                    HttpResponseMessage response = await client.PostAsJsonAsync(RemoveProductUrl, CartUtils.Cart);

                    string strData = await response.Content.ReadAsStringAsync();
                    ResponseUtils.CheckResponseIsSuccess(response, strData);
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true,
                    };

                    Cart cart = JsonSerializer.Deserialize<Cart>(strData, options);
                    CartUtils.SetCartInSession(cart);
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
                TempData["Message"] = "You are not an admin!!!";
                return RedirectToAction("LoginPage", "Home");
            }

        }
        public async Task<ActionResult> UpdateCart()
        {
            if (permission)
            {
                try
                {
                    string id1 = HttpContext.Request.Query["id1"];
                    string quantity1 = HttpContext.Request.Query["quantity1"];
                    int quantity = Int32.Parse(quantity1);
                    int id = Int32.Parse(id1);
                    string UpdateCartProductUrl = "http://localhost:34845/api/Shopping/update/" + id + "/" + quantity;
                    HttpResponseMessage response = await client.PostAsJsonAsync(UpdateCartProductUrl, CartUtils.Cart);

                    string strData = await response.Content.ReadAsStringAsync();
                    ResponseUtils.CheckResponseIsSuccess(response, strData);
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true,
                    };

                    Cart cart = JsonSerializer.Deserialize<Cart>(strData, options);
                    CartUtils.SetCartInSession(cart);
                    TempData["Message"] = "Update successfully!";
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
                TempData["Message"] = "You are not an admin!!!";
                return RedirectToAction("LoginPage", "Home");
            }

        }
        public async Task<ActionResult> AddToCart()
        {
            if (permission)
            {
                try
                {
                    string quantity1 = HttpContext.Request.Query["quantity1"];
                    string id1 = HttpContext.Request.Query["id1"];
                    int quantity = Int32.Parse(quantity1);
                    int id = Int32.Parse(id1);


                    string AddCartProductUrl = "http://localhost:34845/api/Shopping/add/" + id + "/" + quantity;
                    Cart currentCart = CartUtils.Cart;
                    if (currentCart == null)
                    {
                        if (User.IsInRole("Member"))
                        {
                            currentCart = new Cart() { MemberId = loginUser.Id };
                        } else
                        {
                            currentCart = new Cart() { MemberId = "" };
                        }
                    }
                    HttpResponseMessage response = await client.PostAsJsonAsync(AddCartProductUrl, currentCart);

                    string strData = await response.Content.ReadAsStringAsync();
                    ResponseUtils.CheckResponseIsSuccess(response, strData);
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true,
                    };

                    Cart cart = JsonSerializer.Deserialize<Cart>(strData, options);
                    CartUtils.SetCartInSession(cart);

                    TempData["Message"] = "Add successfully!";
                    return RedirectToAction(nameof(Index));


                }
                catch (Exception ex)
                {
                    TempData["Message"] = "Something went wrong!! Error: " + ex.Message;
                    return RedirectToAction(nameof(Index));
                }
            }
            else
            {
                TempData["Message"] = "You are not an admin!!!";
                return RedirectToAction("LoginPage", "Home");
            }

        }

        public async Task<IActionResult> Cart()
        {
            if (permission)
            {
                try
                {
                    Cart cart = CartUtils.Cart;
                    ViewBag.Message = TempData["Message"];
                    if (cart != null)
                    {
                        
                        
                        List<eStoreUser> listMembers = (await _userManager.GetUsersInRoleAsync("Member")).ToList();
                        SelectList selectListMembers = new SelectList(listMembers, "Id", "Email");

                        TempData["ListMembers"] = selectListMembers;
                        var cartList = cart.ListProduct;
                        if (cart.MemberId == "")
                        {
                            ViewBag.ChosenUser = "Please choose a member";
                        }
                        else
                        {
                            eStoreUser currentMem = listMembers.SingleOrDefault(Member => Member.Id == cart.MemberId);
                            ViewBag.ChosenUser = "Current member: " + currentMem.Email;
                        }
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
                TempData["Message"] = "You are not an admin!!!";
                return RedirectToAction("LoginPage", "Home");
            }
        }
        public async Task<ActionResult> Checkout()
        {
            if (permission)
            {
                try
                {
                    Cart cart = CartUtils.Cart;

                    if (cart == null || cart.ListProduct.Count == 0)
                    {
                        TempData["Message"] = "Your cart is empty!";
                        return RedirectToAction(nameof(Index));
                    }
                    if (cart.MemberId == "")
                    {
                        TempData["Message"] = "Please choose a customer!";
                        return RedirectToAction(nameof(Index));
                    }
                    string CheckoutCartProductUrl = "http://localhost:34845/api/Shopping/checkout/" + cart.MemberId;
                    HttpResponseMessage response = await client.PostAsJsonAsync(CheckoutCartProductUrl, CartUtils.Cart);
                    string strData = await response.Content.ReadAsStringAsync();
                    ResponseUtils.CheckResponseIsSuccess(response, strData);
                    CartUtils.DeleteCartInSession();
                    TempData["Message"] = "Checkout successfully!";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    TempData["Message"] = "Something went wrong!! Error: " + ex.Message;
                    return RedirectToAction(nameof(Index));
                }
            }
            else
            {
                TempData["Message"] = "You are not an admin!!!";
                return RedirectToAction("LoginPage", "Home");
            }

        }

        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> SetMember(string MemberEmail)
        {
            if (permission)
            {
                try
                {

                    eStoreUser mem = _userManager.Users.FirstOrDefault(u => u.Email.ToLower().Equals(MemberEmail.ToLower()));
                    if (mem == null)
                    {
                        throw new Exception("User not found!");
                    }
                    Cart cart = CartUtils.Cart;
                    cart.MemberId = mem.Id;
                    CartUtils.SetCartInSession(cart);
                    return RedirectToAction("Cart");
                }
                catch (Exception ex)
                {
                    TempData["Message"] = "Something went wrong!! Error: " + ex.Message;
                    return RedirectToAction(nameof(Index));
                }
            }
            else
            {
                TempData["Message"] = "You are not an admin!!!";
                return RedirectToAction("LoginPage", "Home");
            }
        }

    }

}
