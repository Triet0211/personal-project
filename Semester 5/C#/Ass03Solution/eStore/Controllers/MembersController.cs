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
    public class MembersController : Controller
    {
        IMemberRepository memberRepository = null;
        public MembersController()
        {
            
            memberRepository = new MemberRepository();
        }
        public bool permission
        {
            get
            {
                IHttpContextAccessor _httpContextAccessor = new HttpContextAccessor();
                string role = _httpContextAccessor.HttpContext.Session.GetString("LOGIN_USER");
                if (role == null)
                {
                    return false;
                }
                else
                {
                    if (role.StartsWith("ADMIN"))
                    {
                        return true;
                    }
                    return false;
                }

            }
        }
        // GET: MembersController
        public ActionResult Index()
        {
            if (permission)
            {
                var memberList = memberRepository.GetMembers();
                return View(memberList);
            }
            else
            {
                TempData["Message"] = "You are not an Admin!!!";
                return RedirectToAction("LoginPage", "Home");
            }
            
        }

        // GET: MembersController/Details/5
        public ActionResult Details(int? id)
        {
            if (permission)
            {
                if (id == null)
                {
                    return NotFound();
                }
                var member = memberRepository.GetMemberByID(id.Value);
                if (member == null)
                {
                    return NotFound();
                }
                return View(member);
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
        public ActionResult Create(Member member)
        {
            if(permission)
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        memberRepository.InsertMember(member);
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
        public ActionResult Edit(int? id)
        {
            if (permission)
            {
                if (id == null)
                {
                    return NotFound();
                }
                var mem = memberRepository.GetMemberByID(id.Value);
                if (mem == null)
                {
                    return NotFound();
                }
                return View(mem);
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
        public ActionResult Edit(int id, Member member)
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
                        memberRepository.UpdateMember(member);
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
        public ActionResult Delete(int? id)
        {
            if (permission)
            {
                if (id == null)
                {
                    return NotFound();
                }
                var member = memberRepository.GetMemberByID(id.Value);
                if (member == null)
                {
                    return NotFound();
                }
                return View(member);
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
        public ActionResult Delete(int id)
        {
            if (permission)
            {
                try
                {
                    memberRepository.DeleteMember(id);
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