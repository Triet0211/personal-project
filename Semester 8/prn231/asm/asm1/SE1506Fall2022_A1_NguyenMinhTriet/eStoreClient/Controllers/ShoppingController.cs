using BusinessObject;
using DataAccess.Repositories;
using eStoreClient.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Utils;

namespace eStoreClient.Controllers
{
    public class ShoppingController : Controller
    {
        private readonly HttpClient client = null;
        public bool permission
        {
            get
            {
                return CustomAuthorization.Role() == "ADMIN";
            }
        }
        public ShoppingController()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
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
                    HttpResponseMessage response = await client.PostAsJsonAsync(AddCartProductUrl, CartUtils.Cart ?? new Cart() { MemberId = 0 });

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
                        
                        string GetMembersUrl = "http://localhost:34845/api/Members";
                        HttpResponseMessage response = await client.GetAsync(GetMembersUrl);

                        string strData = await response.Content.ReadAsStringAsync();
                        ResponseUtils.CheckResponseIsSuccess(response, strData);
                        var options = new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true,
                        };
                        List<Member> listMembers = JsonSerializer.Deserialize<List<Member>>(strData, options);
                        SelectList selectListMembers = new SelectList(listMembers, "MemberId", "Email");

                        TempData["ListMembers"] = selectListMembers;
                        var cartList = cart.ListProduct;
                        if (cart.MemberId == 0)
                        {
                            ViewBag.ChosenUser = "Please choose a member";
                        }
                        else
                        {
                            Member currentMem = listMembers.SingleOrDefault(Member => Member.MemberId == cart.MemberId);
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
                    if (cart.MemberId == 0)
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

        public async Task<IActionResult> SetMember(string MemberEmail)
        {
            if (permission)
            {
                try
                {
                    string GetMemberUrl = "http://localhost:34845/api/Members/email/" + MemberEmail;
                    HttpResponseMessage response = await client.GetAsync(GetMemberUrl);

                    string strData = await response.Content.ReadAsStringAsync();
                    ResponseUtils.CheckResponseIsSuccess(response, strData);
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true,
                    };
                    Member mem = JsonSerializer.Deserialize<Member>(strData, options);

                    Cart cart = CartUtils.Cart;
                    cart.MemberId = mem.MemberId;
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
