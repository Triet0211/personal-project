using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SignalRAssignment_SE151127.Common;
using SignalRAssignment_SE151127.Models;
using SignalRAssignment_SE151127.UnitOfWork;
using SignalRAssignment_SE151127.Utils;
using SignalRAssignment_SE151127.ViewModel;

namespace SignalRAssignment_SE151127.Controllers
{
    public class AppUsersController : Controller
    {
        private readonly UnitOfWorkFactory _unitOfWorkFactory;

        public AppUsersController(UnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        // GET: AppUsers/Login
        public IActionResult Login()
        {
            return View();
        }

        // GET: AppUsers/List
        public IActionResult List()
        {
            if (CustomAuthorization.loginUser.Role != CommonEnums.USER_ROLE.ADMINISTRATOR)
            {
                TempData["Message"] = "Invalid request!";
                return RedirectToAction("Index", "Home");
            }
            using(var work = _unitOfWorkFactory.Get)
            {
                var users = work.UserRepository.GetAll().Where(u => !u.Email.ToLower().Equals(AppConfiguration.GetAdminEmail())).ToList();
                return View(users);
            }
        }

        // POST: AppUsers/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(string email, string password)
        {
            using (var work = _unitOfWorkFactory.Get)
            {
                AppUser loginUser = work.UserRepository.GetByEmail(email);
                if (loginUser == null)
                {
                    TempData["Message"] = "Email Not Found!";
                    return RedirectToAction("Login");
                } else
                {
                    if (!password.Equals(loginUser.Password))
                    {
                        TempData["Message"] = "Password is wrong!";
                        return RedirectToAction("Login");
                    } else
                    {
                        Console.Write(email, AppConfiguration.GetAdminEmail());
                        LoginUserVM login = new LoginUserVM()
                        {
                            Email = email,
                            Id = loginUser.UserId,
                            Role = AppConfiguration.GetAdminEmail().ToLower().Equals(email.ToLower()) ? CommonEnums.USER_ROLE.ADMINISTRATOR : CommonEnums.USER_ROLE.USER
                            ,
                        };
                        CustomAuthorization.Login(login);
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
        }

        // GET: AppUsers/Details/5
        public IActionResult Details(int? id)
        {
            if (CustomAuthorization.loginUser == null)
            {
                TempData["Message"] = "You are not logging in!!! Back to login page!";
                return RedirectToAction("Login", "AppUsers");
            }
            if (id == null)
            {
                return NotFound();
            }
            if (id != CustomAuthorization.UserId() && CustomAuthorization.loginUser.Role != CommonEnums.USER_ROLE.ADMINISTRATOR)
            {
                TempData["Message"] = "Invalid request!";
                return RedirectToAction("Index", "Home");
            }
            using (var work = _unitOfWorkFactory.Get)
            {
                var appUser = work.UserRepository.GetById(id ?? 0);
                if (appUser == null)
                {
                    return NotFound();
                }

                return View(appUser);
            }
        }

        // GET: AppUsers/Register
        public IActionResult Register()
        {
            if (CustomAuthorization.loginUser != null && CustomAuthorization.loginUser.Role != CommonEnums.USER_ROLE.ADMINISTRATOR)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        // POST: AppUsers/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register([Bind("UserId,FullName,Address,Email,Password")] AppUser appUser)
        {
            if (CustomAuthorization.loginUser != null && CustomAuthorization.loginUser.Role != CommonEnums.USER_ROLE.ADMINISTRATOR)
            {
                return RedirectToAction("Index", "Home");
            }
            if (ModelState.IsValid)
            {
                using (var work = _unitOfWorkFactory.Get)
                {
                    AppUser loginUser = work.UserRepository.GetByEmail(appUser.Email);
                    if (loginUser != null)
                    {
                        TempData["Message"] = "This email is registered!";
                        return View(appUser);
                    }
                    work.UserRepository.Register(appUser);
                    work.Save();
                    if (CustomAuthorization.loginUser.Role == CommonEnums.USER_ROLE.ADMINISTRATOR)
                    {
                        return RedirectToAction("List");
                    }
                    return RedirectToAction("Login");
                }
            }
            return View(appUser);
        }

        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        // GET: AppUsers/Edit/5
        public IActionResult Edit(int? id)
        {
            if (CustomAuthorization.loginUser == null)
            {
                TempData["Message"] = "You are not logging in!!! Back to login page!";
                return RedirectToAction("Login", "AppUsers");
            }

            if (id == null)
            {
                return NotFound();
            }

            using (var work = _unitOfWorkFactory.Get)
            {
                var appUser = work.UserRepository.GetById(id ?? 0);
                if (appUser == null || (CustomAuthorization.loginUser.Id != id && CustomAuthorization.loginUser.Role != CommonEnums.USER_ROLE.ADMINISTRATOR))
                {
                    return NotFound();
                }

                return View(appUser);
            }
        }

        // POST: AppUsers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? id, [Bind("UserId,FullName,Address,Email,Password")] AppUser appUser)
        {
            if (CustomAuthorization.loginUser == null)
            {
                TempData["Message"] = "You are not logging in!!! Back to login page!";
                return RedirectToAction("Login", "AppUsers");
            }
            if (id != appUser.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (id == null || (CustomAuthorization.loginUser.Id != id && CustomAuthorization.loginUser.Role != CommonEnums.USER_ROLE.ADMINISTRATOR))
                {
                    return NotFound();
                }

                using (var work = _unitOfWorkFactory.Get)
                {
                    var user = work.UserRepository.GetById(id ?? 0);
                    if (appUser == null)
                    {
                        return NotFound();
                    }
                    work.UserRepository.Update(appUser);
                    TempData["Message"] = "Successfully";
                    return RedirectToAction("Index", "Home");
                }
            }
            TempData["Message"] = "Invalid Input! Try Again!!!";
            return View(appUser);
        }

        // GET: AppUsers/Delete/5
        public IActionResult Delete(int? id)
        {
            if (CustomAuthorization.loginUser == null || CustomAuthorization.loginUser.Role != CommonEnums.USER_ROLE.ADMINISTRATOR)
            {
                TempData["Message"] = "You are not authorized to request this!";
                return RedirectToAction("Index", "Home");
            }
            if (id == null)
            {
                return NotFound();
            }
            using (var work = _unitOfWorkFactory.Get)
            {
                var user = work.UserRepository.GetById(id ?? 0);
                if (user == null)
                {
                    return NotFound();
                }
                return View(user);
            }
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (CustomAuthorization.loginUser == null || CustomAuthorization.loginUser.Role != CommonEnums.USER_ROLE.ADMINISTRATOR)
            {
                TempData["Message"] = "You are not authorized to request this!";
                return RedirectToAction("Index", "Home");
            }
            using (var work = _unitOfWorkFactory.Get)
            {
                try
                {
                    work.UserRepository.DeleteUser(id);
                    work.Save();
                }
                catch
                {
                    TempData["Message"] = "This user is having posts!!! Cannot delete!";
                    return RedirectToAction("Index", "Home");
                }
            }
            return RedirectToAction(nameof(List));
        }
    }
}
