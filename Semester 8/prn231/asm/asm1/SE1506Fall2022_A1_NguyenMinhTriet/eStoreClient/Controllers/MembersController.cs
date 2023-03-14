using BusinessObject;
using eStoreClient.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
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
    public class MembersController : Controller
    {
        private readonly HttpClient client = null;
        private string MemberApiUrl = "";
        public bool permission
        {
            get
            {
                return CustomAuthorization.Role() == "ADMIN";
            }
        }

        public MembersController()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            MemberApiUrl = "http://localhost:34845/api/Members";
        }
        public async Task<IActionResult> Index()
        {
            if (permission)
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(MemberApiUrl);
                    string strData = await response.Content.ReadAsStringAsync();
                    ResponseUtils.CheckResponseIsSuccess(response, strData);
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true,
                    };

                    List<Member> listMembers = JsonSerializer.Deserialize<List<Member>>(strData, options);
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
                    MemberApiUrl += "/" + id;

                    HttpResponseMessage response = await client.GetAsync(MemberApiUrl);
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
        public async Task<IActionResult> Create(Member member)
        {
            if (permission)
            {
                try
                {
                    if (member.MemberId == 0)
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
                    MemberApiUrl += "/" + id;

                    HttpResponseMessage response = await client.GetAsync(MemberApiUrl);
                    string strData = await response.Content.ReadAsStringAsync();
                    ResponseUtils.CheckResponseIsSuccess(response, strData);
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true,
                    };

                    Member mem = JsonSerializer.Deserialize<Member>(strData, options);
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
        public async Task<IActionResult> Edit(int id, Member member)
        {
            if (permission)
            {
                try
                {
                    if (id != member.MemberId)
                    {
                        return NotFound();
                    }
                    if (ModelState.IsValid)
                    {
                        MemberApiUrl += "/" + id;
                        HttpResponseMessage response = await client.PutAsJsonAsync(MemberApiUrl, member);
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

        // GET: MembersController/Delete/5
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
                    MemberApiUrl += "/" + id;

                    HttpResponseMessage response = await client.GetAsync(MemberApiUrl);
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