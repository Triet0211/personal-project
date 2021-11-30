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
    public class ProductsController : Controller
    {
        IProductRepository productRepository = null;

        public ProductsController() => productRepository = new ProductRepository();
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
        // GET: ProductsController
        public ActionResult Index()
        {
            if (permission)
            {
                var productList = productRepository.GetProducts();
                return View(productList);
            }
            else
            {
                TempData["Message"] = "You are not an Admin!!!";
                return RedirectToAction("LoginPage", "Home");
            }

        }

        // GET: ProductsController/Details/5
        public ActionResult Details(int? id)
        {
            if (permission)
            {
                if(id == null)
                {
                    return NotFound();
                }
                var product = productRepository.GetProductByID(id.Value);
                if (product == null)
                {
                    return NotFound();
                }
                return View(product);
            }
            else
            {
                TempData["Message"] = "You are not an Admin!!!";
                return RedirectToAction("LoginPage", "Home");
            }
            
        }

        // GET: ProductsController/Create
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

        // POST: ProductsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            if (permission)
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        productRepository.InsertProduct(product);
                    }
                    else
                    {
                        ViewBag.Message = "Something went wrong!!!";
                        return View(product);
                    }
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }
            else
            {
                TempData["Message"] = "You are not an Admin!!!";
                return RedirectToAction("LoginPage", "Home");
            }
            
        }

        // GET: ProductsController/Edit/5
        public ActionResult Edit(int? id)
        {
            if (permission)
            {
                if (id == null)
                {
                    return NotFound();
                }
                var pro = productRepository.GetProductByID(id.Value);
                if (pro == null)
                {
                    return NotFound();
                }
                return View(pro);
            }
            else
            {
                TempData["Message"] = "You are not an Admin!!!";
                return RedirectToAction("LoginPage", "Home");
            }
            
        }

        // POST: ProductsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Product product)
        {
            if (permission)
            {
                try
                {
                    if (id != product.ProductId)
                    {
                        return NotFound();
                    }
                    if (ModelState.IsValid)
                    {
                        productRepository.UpdateProduct(product);
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

        // GET: ProductsController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (permission)
            {
                if (id == null)
                {
                    return NotFound();
                }
                var product = productRepository.GetProductByID(id.Value);
                if (product == null)
                {
                    return NotFound();
                }
                return View(product);
            }
            else
            {
                TempData["Message"] = "You are not an Admin!!!";
                return RedirectToAction("LoginPage", "Home");
            }
            
        }

        // POST: ProductsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            if (permission)
            {
                try
                {
                    productRepository.DeleteProduct(id);
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

        public ActionResult SearchName()
        {
            
            if (permission)
            {
                string searchName = HttpContext.Request.Query["productName"];
                var productList = productRepository.GetProductsByName(searchName);
                return View(productList);
            }
            else
            {
                TempData["Message"] = "You are not an Admin!!!";
                return RedirectToAction("LoginPage", "Home");
            }
        }
        public ActionResult SearchRange()
        {

            if (permission)
            {
                string fromRange = HttpContext.Request.Query["fromPrice"];
                string toRange = HttpContext.Request.Query["toPrice"];
                if(fromRange == null || "".Equals(fromRange) || toRange == null || "".Equals(toRange))
                {
                    return NotFound();
                }
                else
                {
                    decimal from = Decimal.Parse(fromRange);
                    decimal to = Decimal.Parse(toRange);
                    var productList = productRepository.SearchProductsInPriceRange(from, to);
                    return View(productList);
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
