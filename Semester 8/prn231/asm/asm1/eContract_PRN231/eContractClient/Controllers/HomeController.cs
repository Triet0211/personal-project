using BusinessObject.Models;
using eRecruitmentClient.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using Utils;
using Utils.Authentication;

namespace eRecruitmentClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HttpClient client = null;
        private string AuthApiUrl = "";
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            AuthApiUrl = EnvConfig.Get().API_PATH + "/api/auth";
        }

        public IActionResult Index()
        {
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

        public IActionResult Login()
        {
            var properties = new AuthenticationProperties { RedirectUri = Url.Action("GoogleResponse") };
            return Challenge(properties, GoogleDefaults.AuthenticationScheme);
        }

        public async Task<IActionResult> GoogleResponse()
        {
            var authProperties = new AuthenticationProperties
            {
            };
            var result = await HttpContext.AuthenticateAsync();

            var claims = result.Principal.Identities.FirstOrDefault().Claims;
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principle = new ClaimsPrincipal(identity);
            string email = principle.FindFirstValue(ClaimTypes.Email);
            string displayName = principle.FindFirstValue(ClaimTypes.Name);
            string firstName = principle.FindFirstValue("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname");
            string lastName = principle.FindFirstValue("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/surname");
            string avatar = principle.FindFirstValue("urn:google:picture");
            User user = new User()
            {
                Id = "",
                Role = CommonEnums.ROLE.ADMIN,
                Email = email,
                DisplayName = displayName,
                FirstName = firstName,
                LastName = lastName,
                Avatar = avatar,
            };
            AuthApiUrl += "/signin";
            
            HttpResponseMessage response = await client.PostAsJsonAsync(AuthApiUrl, user);

            string strData = await response.Content.ReadAsStringAsync();
            //ResponseUtils.CheckResponseIsSuccess(response, strData);
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            LoginUser loginUser = JsonSerializer.Deserialize<LoginUser>(strData, options);
            //AuthUtils.Login(user);
            //await HttpContext.SignInAsync(
            //    CookieAuthenticationDefaults.AuthenticationScheme,
            //    new ClaimsPrincipal(identity),
            //    authProperties);
            Console.WriteLine(loginUser);
            return BadRequest();
            //else
            //{
            //    using (var work = _unitOfWorkFactory.Get)
            //    {
            //        User user = work.UserRepository.GetFirstOrDefault(p => p.Email.Equals(email));
            //        if (user == null) // first time login
            //        {
            //            User logging = new User()
            //            {
            //                DisplayName = displayName,
            //                Email = email,
            //                Avatar = avatar,
            //                CreatedBy = email,
            //                CreatedAt = DateTime.Now,
            //            };
            //            int id = work.UserRepository.CreateUser(logging);
            //            CustomAuthorization.Login(new LoginUserVM()
            //            {
            //                DisplayName = displayName,
            //                Id = id,
            //                Email = email,
            //                Avatar = avatar,
            //                Role = CommonEnums.ROLE.USER,
            //            });
            //        }
            //        else
            //        {
            //            if (user.IsDeleted)
            //            {
            //                TempData["Error"] = "Your account has been deactivated!! Please contact administrator for more information!";
            //                return Redirect("/Index");
            //            }
            //            CustomAuthorization.Login(new LoginUserVM()
            //            {
            //                DisplayName = displayName,
            //                Id = user.Id,
            //                Email = email,
            //                Avatar = avatar,
            //                Role = CommonEnums.ROLE.USER,
            //            });
            //        }
            //    }
            //    //await HttpContext.SignInAsync(
            //    //    CookieAuthenticationDefaults.AuthenticationScheme,
            //    //    new ClaimsPrincipal(identity),
            //    //    authProperties);
            //    return RedirectToPage("/Index");
            //}
        }
    }
}
