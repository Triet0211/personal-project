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
    public class ProductsController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly HttpClient client = null;
        private string ProductApiUrl = "";
        public LoginUser loginUser { get; }
        private readonly UserManager<eStoreUser> _userManager;
        public bool permission { get; }

        public ProductsController(IHttpContextAccessor httpContextAccessor, UserManager<eStoreUser> userManager)
        {
            _httpContextAccessor = httpContextAccessor;
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            ProductApiUrl = "http://localhost:34845/api/Products";
            _userManager = userManager;
            loginUser = new LoginUser()
            {
                Email = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Email),
                Id = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier),
                Role = _httpContextAccessor.HttpContext.User.IsInRole("Administrator") ? "ADMIN" : "MEMBER"
            };
            permission = _httpContextAccessor.HttpContext.User.IsInRole("Administrator");
        }

        // GET: ProductsController
        public async Task<IActionResult> Index()
        {
            if (permission)
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(ProductApiUrl);
                    string strData = await response.Content.ReadAsStringAsync();
                    ResponseUtils.CheckResponseIsSuccess(response, strData);
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true,
                    };

                    List<Product> listProducts = JsonSerializer.Deserialize<List<Product>>(strData, options);
                    return View(listProducts);
                }
                catch (Exception ex)
                {
                    TempData["Message"] = "Error: " + ex.Message;
                    return RedirectToAction("Index", "Home");
                }

            }
            else
            {
                TempData["Message"] = "You are not an Admin!!!";
                return RedirectToAction("LoginPage", "Home");
            }

        }

        // GET: ProductsController/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (permission)
            {
                try
                {
                    if (id == null)
                    {
                        return NotFound();
                    }

                    ProductApiUrl += "/" + id;
                    HttpResponseMessage response = await client.GetAsync(ProductApiUrl);
                    string strData = await response.Content.ReadAsStringAsync();
                    ResponseUtils.CheckResponseIsSuccess(response, strData);
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true,
                    };

                    Product product = JsonSerializer.Deserialize<Product>(strData, options);
                    if (product == null)
                    {
                        return NotFound();
                    }
                    return View(product);
                }
                catch (Exception ex)
                {
                    TempData["Message"] = "Error: " + ex.Message;
                    return RedirectToAction("Index", "Home");
                }
                
            }
            else
            {
                TempData["Message"] = "You are not an Admin!!!";
                return RedirectToAction("LoginPage", "Home");
            }

        }

        // GET: ProductsController/Create
        public async Task<IActionResult> Create()
        {
            if (permission)
            {
                ProductApiUrl += "/categories";
                HttpResponseMessage response = await client.GetAsync(ProductApiUrl);
                string strData = await response.Content.ReadAsStringAsync();
                ResponseUtils.CheckResponseIsSuccess(response, strData);
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };

                List<Category> listCat = JsonSerializer.Deserialize<List<Category>>(strData, options);
                SelectList selectListCate = new(listCat, "CategoryId", "CategoryName");
                TempData["ListCategories"] = selectListCate;
                return View();
            }
            else
            {
                TempData["Message"] = "You are not an Admin!!!";
                return RedirectToAction("LoginPage", "Home");
            }

        }

        // POST: ProductsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            if (permission)
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        HttpResponseMessage response = await client.PostAsJsonAsync(ProductApiUrl, product);
                        string strData = await response.Content.ReadAsStringAsync();
                        ResponseUtils.CheckResponseIsSuccess(response, strData);
                    }
                    else
                    {
                        ViewBag.Message = "Something went wrong!!!";
                        return View(product);
                    }
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception e)
                {
                    ViewBag.Message = e.Message;
                    return View();
                }
            }
            else
            {
                TempData["Message"] = "You are not an Admin!!!";
                return RedirectToAction("LoginPage", "Home");
            }

        }

        // GET: ProductsController/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (permission)
            {
                try
                {
                    if (id == null)
                    {
                        return NotFound();
                    }
                    string GetProductApiUrl = ProductApiUrl + "/" + id;

                    HttpResponseMessage response = await client.GetAsync(GetProductApiUrl);
                    string strData = await response.Content.ReadAsStringAsync();
                    ResponseUtils.CheckResponseIsSuccess(response, strData);
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true,
                    };

                    Product pro = JsonSerializer.Deserialize<Product>(strData, options);
                    if (pro == null)
                    {
                        return NotFound();
                    }
                    string GetCategoriesApiUrl = ProductApiUrl + "/categories";

                    response = await client.GetAsync(GetCategoriesApiUrl);
                    strData = await response.Content.ReadAsStringAsync();
                    ResponseUtils.CheckResponseIsSuccess(response, strData);

                    List<Category> listCat = JsonSerializer.Deserialize<List<Category>>(strData, options);
                    Category currentCat = listCat.SingleOrDefault(c => c.CategoryId == pro.CategoryId);
                    SelectList selectListCate = new(listCat, "CategoryId", "CategoryName", currentCat);
                 
                    TempData["ListCategories"] = selectListCate;
                    return View(pro);
                }
                catch (Exception ex)
                {
                    TempData["Message"] = "Error: " + ex.Message;
                    return RedirectToAction("Index", "Home");
                }
                
            }
            else
            {
                TempData["Message"] = "You are not an Admin!!!";
                return RedirectToAction("LoginPage", "Home");
            }

        }

        // POST: ProductsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Product product)
        {
            if (permission)
            {
                try
                {
                    if (id != product.ProductId)
                    {
                        return NotFound();
                    }
                    if (ModelState.IsValid)
                    {
                        ProductApiUrl += "/" + id;
                        HttpResponseMessage response = await client.PutAsJsonAsync(ProductApiUrl, product);
                        string strData = await response.Content.ReadAsStringAsync();
                        ResponseUtils.CheckResponseIsSuccess(response, strData);
                    }
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ViewBag.Message = ex.Message;
                    return View();
                }
            }
            else
            {
                TempData["Message"] = "You are not an Admin!!!";
                return RedirectToAction("LoginPage", "Home");
            }

        }

        // GET: ProductsController/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (permission)
            {
                try
                {
                    if (id == null)
                    {
                        return NotFound();
                    }
                    ProductApiUrl += "/" + id;

                    HttpResponseMessage response = await client.GetAsync(ProductApiUrl);
                    string strData = await response.Content.ReadAsStringAsync();
                    ResponseUtils.CheckResponseIsSuccess(response, strData);
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true,
                    };

                    Product product = JsonSerializer.Deserialize<Product>(strData, options);
                    if (product == null)
                    {
                        return NotFound();
                    }
                    return View(product);
                }
                catch (Exception ex)
                {
                    TempData["Message"] = "Error: " + ex.Message;
                    return RedirectToAction("Index", "Home");
                }
                
            }
            else
            {
                TempData["Message"] = "You are not an Admin!!!";
                return RedirectToAction("LoginPage", "Home");
            }

        }

        // POST: ProductsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            if (permission)
            {
                try
                {
                    ProductApiUrl += "/" + id;
                    HttpResponseMessage response = await client.DeleteAsync(ProductApiUrl);
                    string strData = await response.Content.ReadAsStringAsync();
                    ResponseUtils.CheckResponseIsSuccess(response, strData);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ViewBag.Message = ex.Message;
                    return View();
                }
            }
            else
            {
                TempData["Message"] = "You are not an Admin!!!";
                return RedirectToAction("LoginPage", "Home");
            }

        }

        public async Task<IActionResult> SearchName()
        {

            if (permission)
            {
                try
                {
                    string searchName = HttpContext.Request.Query["productName"];
                    ProductApiUrl += "/name?searchName=" + searchName;

                    HttpResponseMessage response = await client.GetAsync(ProductApiUrl);
                    string strData = await response.Content.ReadAsStringAsync();
                    ResponseUtils.CheckResponseIsSuccess(response, strData);
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true,
                    };

                    List<Product> productList = JsonSerializer.Deserialize<List<Product>>(strData, options);
                    return View(productList);
                }
                catch (Exception ex)
                {
                    TempData["Message"] = "Error: " + ex.Message;
                    return RedirectToAction("Index", "Home");
                }
                
            }
            else
            {
                TempData["Message"] = "You are not an Admin!!!";
                return RedirectToAction("LoginPage", "Home");
            }
        }
        public async Task<IActionResult> SearchRange()
        {
            if (permission)
            {
                try
                {
                    string fromRange = HttpContext.Request.Query["fromPrice"];
                    string toRange = HttpContext.Request.Query["toPrice"];
                    ProductApiUrl += "/range?fromPrice=" + fromRange + "&toPrice=" + toRange;

                    if (fromRange == null || "".Equals(fromRange) || toRange == null || "".Equals(toRange))
                    {
                        return NotFound();
                    }
                    else
                    {
                        HttpResponseMessage response = await client.GetAsync(ProductApiUrl);
                        string strData = await response.Content.ReadAsStringAsync();
                        ResponseUtils.CheckResponseIsSuccess(response, strData);
                        var options = new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true,
                        };

                        List<Product> productList = JsonSerializer.Deserialize<List<Product>>(strData, options);
                        return View(productList);
                    }
                }
                catch (Exception ex)
                {
                    TempData["Message"] = "Error: " + ex.Message;
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                TempData["Message"] = "You are not an Admin!!!";
                return RedirectToAction("LoginPage", "Home");
            }
        }
    }
}
