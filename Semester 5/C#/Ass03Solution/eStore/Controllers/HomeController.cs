using BusinessObject;
using DataAccess.Repository;
using eStore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace eStore.Controllers
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
            string user = HttpContext.Session.GetString("LOGIN_USER");
            if(user != null)
            {
                if (user.StartsWith("ADMIN"))
                {
                    return RedirectToAction("Index", "Products");
                }
                else
                {
                    return RedirectToAction("Index", "Shopping");
                }
            }
            
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
            return View("Login");
        }
        public IActionResult Login(string email, string password)
        {
            try
            {
                IMemberRepository memberRepository = new MemberRepository();
                Member loginAdmin = memberRepository.LoginAdmin(email, password);
                if(loginAdmin != null)
                {
                    HttpContext.Session.SetString("LOGIN_USER", "ADMIN: " + loginAdmin.Email);
                }
                else
                {
                    Member loginMember = memberRepository.LoginMember(email, password);
                    if(loginMember != null)
                    {
                        HttpContext.Session.SetString("LOGIN_USER", "MEMBER: " + loginMember.Email);
                    }
                    else
                    {
                        TempData["Message"] = "Account Not Found!";
                        return RedirectToAction("LoginPage");
                    }
                }
                return RedirectToAction("Index");
            }catch(Exception ex)
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
