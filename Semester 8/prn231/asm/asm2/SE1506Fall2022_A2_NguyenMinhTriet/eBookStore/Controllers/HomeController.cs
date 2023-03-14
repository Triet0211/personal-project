using BusinessObject;
using eBookStore.Models;
using eBookStore.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

namespace eBookStore.Controllers
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

        public async Task<IActionResult> Login(string email, string password)
        {
            try
            {
                string LoginApiUrl = "http://localhost:43969/api/Users/login";
                LoginObject loginObject = new LoginObject()
                {
                    Email = email,
                    Password = password,
                };
                string res = await HttpUtils.SendPostRequestAsync<LoginObject>(LoginApiUrl, loginObject);
                LoginUser loginUser = HttpUtils.DeserializeResponse<LoginUser>(res);

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

        public async Task<IActionResult> RegisterPage()
        {
            ViewBag.Message = TempData["Message"];
            if (CustomAuthorization.loginUser != null)
            {
                return View("Home");
            }

            try
            {
                string GetPublishersUrl = "http://localhost:43969/odata/Publishers?$select=PubId,PublisherName";

                string res = await HttpUtils.SendGetRequestAsync(GetPublishersUrl);
                dynamic temp = JObject.Parse(res);

                List<Publisher> listPub = ((JArray)temp.value).Select(x => new Publisher()
                {
                    PubId = (int)x["PubId"],
                    PublisherName = (string)x["PublisherName"]
                }).ToList();
                SelectList selectListPub = new(listPub, "PubId", "PublisherName");
                TempData["ListPublishers"] = selectListPub;
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Something went wrong - Error: " + ex.Message;
                return RedirectToAction("Index");
            }

            return View("Register");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(User user)
        {
            try
            {
                if (string.IsNullOrEmpty(user.EmailAddress))
                {
                    throw new Exception("Invalid email!");
                }

                string RegisterApiUrl = "http://localhost:43969/api/Users";

                string res = await HttpUtils.SendPostRequestAsync<User>(RegisterApiUrl, user);

                TempData["Message"] = "Successfully!";

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Something went wrong - Error: " + ex.Message;
                return RedirectToAction("RegisterPage");
            }
        }

        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
