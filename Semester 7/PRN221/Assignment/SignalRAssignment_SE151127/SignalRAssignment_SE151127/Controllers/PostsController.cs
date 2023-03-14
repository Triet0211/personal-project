using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using SignalRAssignment_SE151127.Common;
using SignalRAssignment_SE151127.Hubs;
using SignalRAssignment_SE151127.Models;
using SignalRAssignment_SE151127.UnitOfWork;
using SignalRAssignment_SE151127.Utils;
using SignalRAssignment_SE151127.ViewModel;

namespace SignalRAssignment_SE151127.Controllers
{
    public class PostsController : Controller
    {
        private readonly UnitOfWorkFactory _unitOfWorkFactory;
        private readonly IHubContext<SignalRServer> _signalRHub;


        public PostsController(UnitOfWorkFactory unitOfWorkFactory, IHubContext<SignalRServer> signalRHub)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            _signalRHub = signalRHub;
        }

        // GET: Posts
        public IActionResult Index()
        {
            if (CustomAuthorization.loginUser == null)
            {
                TempData["Message"] = "You are not logging in!!! Back to login page!";
                return RedirectToAction("Login", "AppUsers");
            }
            //IList<Post> posts;
            //using (var work = _unitOfWorkFactory.Get)
            //{
            //    posts = work.PostRepository.GetAll().ToList();
            //}
            //return View(posts);
            return View();
        }

        [HttpGet]
        public IActionResult GetPosts()
        {
            using (var work = _unitOfWorkFactory.Get)
            {
                var posts = work.PostRepository.GetAll("Author,Category").ToList();
                var list = new ArrayList() ;
                for (int i = 0; i < posts.Count; i++)
                {
                    PostVM res = new PostVM()
                    {
                        Author = posts[i].Author,
                        Category = posts[i].Category,
                        Content = posts[i].Content,
                        CreatedDate = posts[i].CreatedDate,
                        isLoggingIn = CustomAuthorization.loginUser != null && (CustomAuthorization.loginUser.Role.Equals(CommonEnums.USER_ROLE.ADMINISTRATOR) || posts[i].Author.UserId == CustomAuthorization.loginUser.Id),
                        PostId = posts[i].PostId,
                        PublishStatus = posts[i].PublishStatus,
                        Title = posts[i].Title,
                        UpdatedDate = posts[i].UpdatedDate,
                    };
                    list.Add(res);
                }
               
                return Ok(list);
            }
        }


        // GET: Posts/Details/5
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
            using (var work = _unitOfWorkFactory.Get)
            {
                var post = work.PostRepository.GetById(id ?? 0, "Author,Category");
                if (post == null)
                {
                    return NotFound();
                }
                return View(post);
            }
        }

        // GET: Posts/Create
        public IActionResult Create()
        {
            if (CustomAuthorization.loginUser == null)
            {
                TempData["Message"] = "You are not logging in!!! Back to login page!";
                return RedirectToAction("Login", "AppUsers");
            }
            using (var work = _unitOfWorkFactory.Get)
            {
                List<PostCategory> categories = work.CategoryRepository.GetAll().ToList();
                SelectList cateList = new SelectList(categories, "CategoryId", "CategoryName");
                ViewBag.Categories = cateList;
                return View();
            }
        }

        // POST: Posts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int Category, [Bind("PostId,CreatedDate,UpdatedDate,Title,Content,PublishStatus")] Post post)
        {
            if (CustomAuthorization.loginUser == null)
            {
                TempData["Message"] = "You are not logging in!!! Back to login page!";
                return RedirectToAction("Login", "AppUsers");
            }
            post.CreatedDate = DateTime.Now;
            post.UpdatedDate = null;
            post.PublishStatus = CommonEnums.POST_PUBLISH_STATUS.PUBLIC;
            try
            {
                using (var work = _unitOfWorkFactory.Get)
                {
                    AppUser login = work.UserRepository.GetById(CustomAuthorization.loginUser.Id);
                    PostCategory cate = work.CategoryRepository.GetById(Category);
                    post.Author = login;
                    post.Category = cate;
                    work.PostRepository.Add(post);
                    work.Save();
                    await _signalRHub.Clients.All.SendAsync("LoadPosts");
                    return RedirectToAction(nameof(Index));
                }
            } catch (Exception ex)
            {
                TempData["Message"] = "Somethong went wrong: " + ex.Message;
                using (var work = _unitOfWorkFactory.Get)
                {
                    List<PostCategory> categories = work.CategoryRepository.GetAll().ToList();
                    SelectList cateList = new SelectList(categories, "CategoryId", "CategoryName");
                    ViewBag.Categories = cateList;
                }
                return View(post);
            }
                
        }

        // GET: Posts/Edit/5
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
                var post = work.PostRepository.GetById(id ?? 0, "Author,Category");
                if (post == null)
                {
                    return NotFound();
                }
                if (post.Author.UserId != CustomAuthorization.loginUser.Id && !CustomAuthorization.loginUser.Role.Equals(CommonEnums.USER_ROLE.ADMINISTRATOR))
                {
                    return BadRequest();
                }
                List<PostCategory> categories = work.CategoryRepository.GetAll().ToList();
                SelectList cateList = new SelectList(categories, "CategoryId", "CategoryName");
                ViewBag.Categories = cateList;
                return View(post);
            }
        }

        // POST: Posts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, int Category, [Bind("PostId,CreatedDate,UpdatedDate,Title,Content,PublishStatus")] Post post)
        {
            if (CustomAuthorization.loginUser == null)
            {
                TempData["Message"] = "You are not logging in!!! Back to login page!";
                return RedirectToAction("Login", "AppUsers");
            }
            if (id != post.PostId)
            {
                return NotFound();
            }
            try
            {
                using (var work = _unitOfWorkFactory.Get)
                {
                    var oldPost = work.PostRepository.GetById(id, "Author,Category");
                    var cate = work.CategoryRepository.GetById(Category);
                    post.CreatedDate = oldPost.CreatedDate;
                    post.UpdatedDate = DateTime.Now;
                    post.Category = cate;
                    
                    work.PostRepository.UpdatePost(post);
                    await _signalRHub.Clients.All.SendAsync("LoadPosts");
                }
            }
            catch (Exception ex)
            {
                if (!PostExists(post.PostId))
                {
                    return NotFound();
                }
                else
                {
                    TempData["Message"] = "Somethong went wrong: " + ex.Message;
                    using (var work = _unitOfWorkFactory.Get)
                    {
                        List<PostCategory> categories = work.CategoryRepository.GetAll().ToList();
                        SelectList cateList = new SelectList(categories, "CategoryId", "CategoryName");
                        ViewBag.Categories = cateList;
                    }
                    return View(post);
                }
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Posts/Delete/5
        public IActionResult Delete(int? id)
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
                var post = work.PostRepository.GetById(id ?? 0, "Author,Category");
                if (post == null)
                {
                    return NotFound();
                }
                if (post.Author.UserId != CustomAuthorization.loginUser.Id && !CustomAuthorization.loginUser.Role.Equals(CommonEnums.USER_ROLE.ADMINISTRATOR))
                {
                    return BadRequest();
                }
                return View(post);
            }
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (CustomAuthorization.loginUser == null)
            {
                TempData["Message"] = "You are not logging in!!! Back to login page!";
                return RedirectToAction("Login", "AppUsers");
            }
            using (var work = _unitOfWorkFactory.Get)
            {
                work.PostRepository.DeletePost(id);
                work.Save();
                await _signalRHub.Clients.All.SendAsync("LoadPosts");
            }
            return RedirectToAction(nameof(Index));
        }

        private bool PostExists(int id)
        {
            using (var work = _unitOfWorkFactory.Get)
            {
                var post = work.PostRepository.GetById(id, "Author,Category");
                return (post != null);
            }
        }
    }
}
