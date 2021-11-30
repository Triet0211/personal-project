using BusinessObject;
using DataAccess.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eStore.Controllers
{
    public class ProfileController : Controller
    {
        public string role
        {
            get
            {
                IHttpContextAccessor _httpContextAccessor = new HttpContextAccessor();
                return _httpContextAccessor.HttpContext.Session.GetString("LOGIN_USER");
            }
        }
        public IMemberRepository memRepo = new MemberRepository();
        // GET: ProfileController
        public ActionResult Index()
        {
            if (role != null)
            {
                
                if (role.StartsWith("MEMBER"))
                {

                    var member = memRepo.GetMemberByEmail(role.Substring(8));
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
        public ActionResult Edit(int? id)
        {
            if (role != null)
            {

                if (role.StartsWith("MEMBER"))
                {
                    if (id == null)
                    {
                        return NotFound();
                    }
                    var mem = memRepo.GetMemberByID(id.Value);
                    if (mem == null)
                    {
                        return NotFound();
                    }
                    return View(mem);
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
        public ActionResult Edit(int id, Member member)
        {
            if (role != null)
            {

                if (role.StartsWith("MEMBER"))
                {
                    try
                    {
                        if (id != member.MemberId)
                        {
                            return NotFound();
                        }
                        if (ModelState.IsValid)
                        {
                            memRepo.UpdateMember(member);
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
