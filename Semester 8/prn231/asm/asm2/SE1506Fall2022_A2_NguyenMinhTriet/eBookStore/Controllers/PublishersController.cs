using eBookStore.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System;
using BusinessObject;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace eBookStore.Controllers
{
    public class PublishersController : Controller
    {
        public bool permission
        {
            get
            {
                return CustomAuthorization.Role() == 0;
            }
        }
        // GET: PublishersController
        public async Task<IActionResult> Index()
        {
            if (permission)
            {
                try
                {
                    string res = await HttpUtils.SendGetRequestAsync("http://localhost:43969/odata/Publishers");
                    dynamic temp = JObject.Parse(res);

                    List<Publisher> listPub = ((JArray)temp.value).Select(x => new Publisher()
                    {
                        PubId = (int)x["PubId"],
                        PublisherName = (string)x["PublisherName"],
                        City = (string)x["City"],
                        Country = (string)x["Country"],
                        State = (string)x["State"],
                    }).ToList();
                    return View(listPub);
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

        // GET: PublishersController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (permission)
            {
                try
                {
                    string res = await HttpUtils.SendGetRequestAsync("http://localhost:43969/odata/Publishers/" + id);
                    Publisher pub = HttpUtils.DeserializeResponse<Publisher>(res);
                    pub.PubId = id;
                    return View(pub);
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

        // GET: PublishersController/Create
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

        // POST: PublishersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Publisher pub)
        {
            if (permission)
            {
                try
                {
                    string res = await HttpUtils.SendPostRequestAsync<Publisher>("http://localhost:43969/odata/Publishers", pub);
                    return RedirectToAction(nameof(Index));
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

        // GET: PublishersController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (permission)
            {
                try
                {
                    string res = await HttpUtils.SendGetRequestAsync("http://localhost:43969/odata/Publishers/" + id);
                    Publisher pub = HttpUtils.DeserializeResponse<Publisher>(res);
                    pub.PubId = id;
                    return View(pub);
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

        // POST: PublishersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [FromForm] Publisher pub)
        {

            if (permission)
            {
                try
                {
                    pub.PubId = id;
                    string res = await HttpUtils.SendPutRequestAsync<Publisher>("http://localhost:43969/odata/Publishers/" + pub.PubId, pub);
                    return RedirectToAction(nameof(Index));
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

        // GET: PublishersController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (permission)
            {
                try
                {
                    string res = await HttpUtils.SendGetRequestAsync("http://localhost:43969/odata/Publishers/" + id);
                    Publisher pub = HttpUtils.DeserializeResponse<Publisher>(res);
                    pub.PubId = id;
                    return View(pub);
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

        // POST: PublishersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, [FromForm] Publisher pub)
        {
            if (permission)
            {
                try
                {
                    string res = await HttpUtils.SendDeleteRequestAsync("http://localhost:43969/odata/Publishers/" + id);
                    return RedirectToAction(nameof(Index));
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
