using BusinessObject;
using eStore.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
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
    [Authorize(Roles = "Administrator")]
    public class MembersController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly HttpClient client = null;
        private string MemberApiUrl = "";
        public LoginUser loginUser { get; }
        private readonly UserManager<eStoreUser> _userManager;
        public bool permission { get; }

        public MembersController(IHttpContextAccessor httpContextAccessor, UserManager<eStoreUser> userManager)
        {
            _httpContextAccessor = httpContextAccessor;
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            MemberApiUrl = "http://localhost:34845/api/Members";
            _userManager = userManager;
            loginUser = new LoginUser()
            {
                Email = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Email),
                Id = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier),
                Role = _httpContextAccessor.HttpContext.User.IsInRole("Administrator") ? "ADMIN" : "MEMBER"
            };
            permission = _httpContextAccessor.HttpContext.User.IsInRole("Administrator");
        }
        public async Task<IActionResult> Index()
        {
            if (permission)
            {
                try
                {
                    List<eStoreUser> listMembers = (await _userManager.GetUsersInRoleAsync("Member")).ToList();
                    return View(listMembers);
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

        // GET: MembersController/Details/5
        public async Task<IActionResult> Details(string? id)
        {
            if (permission)
            {
                try
                {
                    if (id == null)
                    {
                        return NotFound();
                    }
                    eStoreUser mem = _userManager.Users.FirstOrDefault(u => u.Id == id);
                    if (mem == null)
                    {
                        return NotFound();
                    }
                    return View(mem);
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

        // GET: MembersController/Create
        public ActionResult Create()
        {
            if (permission)
            {
                return View();
            }
            else
            {
                TempData["Message"] = "You are not an Admin!!!";
                return RedirectToAction("LoginPage", "Home");
            }

        }

        // POST: MembersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(eStoreUser member)
        {
            if (permission)
            {
                try
                {
                    if (member.Id == "")
                    {
                        throw new Exception("MemberId cannot be 0!");
                    }
                    if (ModelState.IsValid)
                    {
                        HttpResponseMessage response = await client.PostAsJsonAsync(MemberApiUrl, member);
                        string strData = await response.Content.ReadAsStringAsync();
                        ResponseUtils.CheckResponseIsSuccess(response, strData);
                    }
                    else
                    {
                        ViewBag.Message = "Something went wrong!!!";
                        return View(member);
                    }
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ViewBag.Message = ex.Message;
                    return View(member);
                }
            }
            else
            {
                TempData["Message"] = "You are not an Admin!!!";
                return RedirectToAction("LoginPage", "Home");
            }

        }

        // GET: MembersController/Edit/5
        public async Task<IActionResult> Edit(string? id)
        {
            if (permission)
            {
                try
                {
                    if (id == null)
                    {
                        return NotFound();
                    }
                    eStoreUser mem = _userManager.Users.FirstOrDefault(u => u.Id == id);

                    if (mem == null)
                    {
                        return NotFound();
                    }
                    return View(mem);
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

        // POST: MembersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, eStoreUser member)
        {
            if (permission)
            {
                try
                {
                    if (id != member.Id)
                    {
                        return NotFound();
                    }
                    if (ModelState.IsValid)
                    {
                        var currentUser = _userManager.Users.FirstOrDefault(user => user.Id == id);
                        currentUser.FirstName = member.FirstName;
                        currentUser.LastName = member.LastName;
                        IdentityResult result = await _userManager.UpdateAsync(currentUser);

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

        // GET: MembersController/Delete/5
        public async Task<IActionResult> Delete(string? id)
        {
            if (permission)
            {
                try
                {
                    if (id == null)
                    {
                        return NotFound();
                    }
                    eStoreUser mem = _userManager.Users.FirstOrDefault(u => u.Id == id);

                    if (mem == null)
                    {
                        return NotFound();
                    }
                    return View(mem);
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

        // POST: MembersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete (int id)
        {
            if (permission)
            {
                try
                {
                    MemberApiUrl += "/" + id;
                    HttpResponseMessage response = await client.DeleteAsync(MemberApiUrl);
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
    }
}