using BusinessObject;
using eStore.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;

namespace eStore.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly HttpClient client = null;
        private string OrderApiUrl = "";
        public LoginUser loginUser { get; set; }
        private readonly UserManager<eStoreUser> _userManager;
        public OrdersController(IHttpContextAccessor httpContextAccessor, UserManager<eStoreUser> userManager)
        {
            _httpContextAccessor = httpContextAccessor;
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            OrderApiUrl = "http://localhost:34845/api/Orders";
            _userManager = userManager;
            loginUser = new LoginUser()
            {
                Email = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Email),
                Id = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier),
                Role = _httpContextAccessor.HttpContext.User.IsInRole("Administrator") ? "ADMIN" : "MEMBER"
            };

        }
        public async Task<ActionResult> ReportDate(string startDate, string endDate)
        {
            try
            {
                if (loginUser != null)
                {
                    if (loginUser.Role == "MEMBER")
                    {
                        TempData["Message"] = "Your account's role does not support this function!";
                        ViewBag.Role = "Member";
                    }
                    else if (loginUser.Role == "ADMIN")
                    {
                        if (startDate.ToString().Equals("") || endDate.ToString().Equals(""))
                        {
                            TempData["Message"] = "Please choose valid date!!!";
                        }
                        else
                        {
                            OrderApiUrl += "/report";
                            ReportPayload reportPayload = new ReportPayload()
                            {
                                StartDate = DateTime.Parse(startDate),
                                EndDate = DateTime.Parse(endDate),
                            };
                            HttpResponseMessage response = await client.PostAsJsonAsync(OrderApiUrl, reportPayload);
                            string strData = await response.Content.ReadAsStringAsync();
                            ResponseUtils.CheckResponseIsSuccess(response, strData);
                            var options = new JsonSerializerOptions
                            {
                                PropertyNameCaseInsensitive = true,
                            };

                            Tuple<IEnumerable<Order>, decimal> report = JsonSerializer.Deserialize<Tuple<IEnumerable<Order>, decimal>>(strData, options);
                            ViewBag.Role = "Admin";
                            ViewBag.Total = report.Item2;
                            return View(report.Item1);
                        }

                    }
                    ViewBag.Message = TempData["Message"];
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["Message"] = "You are not logging in!!! Back to login page!";
                    return RedirectToAction("LoginPage", "Home");
                }
            }
            catch (Exception e)
            {
                TempData["Message"] = e.Message;
                return RedirectToAction("Index", "Home");
            }
            
        }
        // GET: OrderController
        public async Task<ActionResult> Index()
        {
            try
            {
                if (loginUser != null)
                {
                    IEnumerable<Order> orderList = new List<Order>();

                    if (loginUser.Role == "MEMBER")
                    {
                        ViewBag.Role = "Member";
                        OrderApiUrl += "/member/" + loginUser.Id;
                    }
                    else if (loginUser.Role == "ADMIN")
                    {
                        ViewBag.Role = "Admin";
                        OrderApiUrl += "/member/list";
                    }
                    HttpResponseMessage response = await client.GetAsync(OrderApiUrl);
                    string strData = await response.Content.ReadAsStringAsync();
                    ResponseUtils.CheckResponseIsSuccess(response, strData);
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true,
                    };
                    orderList = JsonSerializer.Deserialize<IEnumerable<Order>>(strData, options);

                    ViewBag.Message = TempData["Message"];
                    return View(orderList);
                }
                else
                {
                    TempData["Message"] = "You are not logging in!!! Back to login page!";
                    return RedirectToAction("LoginPage", "Home");
                }
            }
            catch (Exception e)
            {
                TempData["Message"] = e.Message;
                return RedirectToAction("Index", "Home");
            }
            
        }

        // GET: OrderController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            try
            {
                if (loginUser != null)
                {
                    if (loginUser.Role == "MEMBER")
                    {
                        ViewBag.Role = "Member";
                    }
                    else if (loginUser.Role == "ADMIN")
                    {
                        ViewBag.Role = "Admin";
                    }
                    OrderApiUrl += "/" + id;
                    HttpResponseMessage response = await client.GetAsync(OrderApiUrl);
                    string strData = await response.Content.ReadAsStringAsync();
                    ResponseUtils.CheckResponseIsSuccess(response, strData);
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true,
                    };
                    IEnumerable<OrderDetail> details = JsonSerializer.Deserialize<IEnumerable<OrderDetail>>(strData, options);
                    return View(details);
                }
                else
                {
                    TempData["Message"] = "You are not logging in!!! Back to login page!";
                    return RedirectToAction("LoginPage", "Home");
                }
            }
            catch (Exception e)
            {
                TempData["Message"] = e.Message;
                return RedirectToAction("Index", "Home");
            }
            

        }
        // GET: OrderController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                if (loginUser != null)
                {
                    OrderApiUrl += "/" + id;
                    HttpResponseMessage response = await client.DeleteAsync(OrderApiUrl);
                    string strData = await response.Content.ReadAsStringAsync();
                    ResponseUtils.CheckResponseIsSuccess(response, strData);
                    TempData["Message"] = "Remove Successfully!!!";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["Message"] = "You are not logging in!!! Back to login page!";
                    return RedirectToAction("LoginPage", "Home");
                }
            }
            catch (Exception e)
            {
                TempData["Message"] = e.Message;
                return RedirectToAction("Index", "Home");
            }
            

        }
    }
}
