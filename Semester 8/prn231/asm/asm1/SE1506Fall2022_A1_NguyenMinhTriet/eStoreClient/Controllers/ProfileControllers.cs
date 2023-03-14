using BusinessObject;
using eStoreClient.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class ProfileController : Controller
    {
        private readonly HttpClient client = null;
        private string ProfileApiUrl = "";
        public LoginUser loginUser
        {
            get
            {
                return CustomAuthorization.loginUser;
            }
        }

        public ProfileController()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            ProfileApiUrl = "http://localhost:34845/api/Profile";
        }
        // GET: ProfileController
        public async Task<IActionResult> Index()
        {
            if (loginUser != null)
            {

                if (loginUser.Role == "MEMBER")
                {
                    ProfileApiUrl += "/" + loginUser.Id;
                    HttpResponseMessage response = await client.GetAsync(ProfileApiUrl);
                    string strData = await response.Content.ReadAsStringAsync();
                    ResponseUtils.CheckResponseIsSuccess(response, strData);
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true,
                    };

                    Member member = JsonSerializer.Deserialize<Member>(strData, options);
                    return View(member);
                }
                else
                {
                    TempData["Message"] = "You are not a Member!!! Back to login page!";
                    return RedirectToAction("LoginPage", "Home");
                }
            }
            else
            {
                TempData["Message"] = "You are not a Member!!! Back to login page!";
                return RedirectToAction("LoginPage", "Home");
            }
        }

        // GET: ProfileController/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (loginUser != null)
            {

                if (loginUser.Role == "MEMBER")
                {
                    if (id == null)
                    {
                        return NotFound();
                    }
                    ProfileApiUrl += "/" + id;
                    HttpResponseMessage response = await client.GetAsync(ProfileApiUrl);
                    string strData = await response.Content.ReadAsStringAsync();
                    ResponseUtils.CheckResponseIsSuccess(response, strData);
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true,
                    };

                    Member member = JsonSerializer.Deserialize<Member>(strData, options);
                    if (member == null)
                    {
                        return NotFound();
                    }
                    return View(member);
                }
                else
                {
                    TempData["Message"] = "You are not a Member!!! Back to login page!";
                    return RedirectToAction("LoginPage", "Home");
                }
            }
            else
            {
                TempData["Message"] = "You are not a Member!!! Back to login page!";
                return RedirectToAction("LoginPage", "Home");
            }
        }

        // POST: ProfileController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Member member)
        {
            if (loginUser != null)
            {

                if (loginUser.Role == "MEMBER")
                {
                    try
                    {
                        if (id != member.MemberId)
                        {
                            return NotFound();
                        }
                        if (ModelState.IsValid)
                        {
                            ProfileApiUrl += "/" + id;
                            HttpResponseMessage response = await client.PutAsJsonAsync(ProfileApiUrl, member);
                            string strData = await response.Content.ReadAsStringAsync();
                            ResponseUtils.CheckResponseIsSuccess(response, strData);
                            TempData["Message"] = "Update successfully!! Logout!";
                            return RedirectToAction("Logout", "Home");
                        }
                        else
                        {
                            return RedirectToAction(nameof(Index));
                        }

                    }
                    catch (Exception ex)
                    {
                        ViewBag.Message = ex.Message;
                        return View();
                    }
                }
                else
                {
                    TempData["Message"] = "You are not a Member!!! Back to login page!";
                    return RedirectToAction("LoginPage", "Home");
                }
            }
            else
            {
                TempData["Message"] = "You are not a Member!!! Back to login page!";
                return RedirectToAction("LoginPage", "Home");
            }
        }
    }
}
