using BusinessObject;
using eStoreClient.Models;
using eStoreClient.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Utils;

namespace eStoreClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IConfiguration config;
        public HomeController(ILogger<HomeController> logger, IConfiguration iConfig)
        {
            config = iConfig;
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.Message = TempData["Message"];
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult LoginPage()
        {
            ViewBag.Message = TempData["Message"];
            if (CustomAuthorization.loginUser != null)
            {
                return View("Home");
            }
            return View("Login");
        }
        public IActionResult ShoppingPage()
        {
            ViewBag.Message = TempData["Message"];
            return RedirectToAction("Index", "Shopping");
        }
        public async Task<IActionResult> Login(string email, string password)
        {
            try
            {
                HttpClient client = new HttpClient();
                var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                string LoginApiUrl = "http://localhost:34845/api/Members/login";
                LoginObject loginObject = new LoginObject()
                {
                    Email = email,
                    Password = password,
                };

                HttpResponseMessage response = await client.PostAsJsonAsync(LoginApiUrl, loginObject);
                
                string strData = await response.Content.ReadAsStringAsync();
                ResponseUtils.CheckResponseIsSuccess(response, strData);
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };

                LoginUser loginUser = JsonSerializer.Deserialize<LoginUser>(strData, options);
                if (loginUser != null)
                {
                    HttpContext.Session.SetString("LoginUser", JsonUtils.SerializeComplexData(loginUser));
                }
                else
                {
                    TempData["Message"] = "Account Not Found!";
                    return RedirectToAction("LoginPage");
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Something went wrong - Error: " + ex.Message;
                return RedirectToAction("LoginPage");
            }
        }
        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
