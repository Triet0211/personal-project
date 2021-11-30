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
    public class OrdersController : Controller
    {
        IOrderRepository orderRepo = null;
        IOrderDetailRepository orderDetailRepo = null;
        public string role
        {
            get
            {
                IHttpContextAccessor _httpContextAccessor = new HttpContextAccessor();
                return _httpContextAccessor.HttpContext.Session.GetString("LOGIN_USER");
            }
        }
        public OrdersController()
        {
            orderRepo = new OrderRepository();
            orderDetailRepo = new OrderDetailRepository();
        }
        public ActionResult Report()
        {
            if (role != null)
            {
                

                if (role.StartsWith("MEMBER"))
                {
                    TempData["Message"] = "Your account's role does not support this function!";
                    ViewBag.Role = "Member";
                }
                else if (role.StartsWith("ADMIN"))
                {
                    string start = HttpContext.Request.Query["startDate"];
                    string end = HttpContext.Request.Query["endDate"];
                    if(start == null || end == null || start.Equals("") || end.Equals(""))
                    {
                        TempData["Message"] = "Please choose valid date!!!";
                    }
                    else
                    {
                        DateTime start1 = DateTime.Parse(start);
                        DateTime startDate = start1.Date + new TimeSpan(0, 0, 0);
                        DateTime end1 = DateTime.Parse(end);
                        DateTime endDate = end1.Date + new TimeSpan(23, 59, 59);
                        Tuple<IEnumerable<Order>, decimal> report = orderRepo.GetOrdersBetweenDate(startDate, endDate);
                        ViewBag.Role = "Admin";
                        ViewBag.Total = report.Item2;
                        return View(report.Item1);
                    }
                    
                }
                ViewBag.Message = TempData["Message"];
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Message"] = "You are not logging in!!! Back to login page!";
                return RedirectToAction("LoginPage", "Home");
            }
        }
        // GET: OrderController
        public ActionResult Index()
        {
            if (role != null)
            {
                IEnumerable<Order> orderList = new List<Order>();
                if (role.StartsWith("MEMBER"))
                {
                    IMemberRepository memRepo = new MemberRepository();
                    orderList = orderRepo.GetOrdersByMemebrId(memRepo.GetMemberByEmail(role.Substring(8)).MemberId);
                    ViewBag.Role = "Member";
                }
                else if (role.StartsWith("ADMIN")){
                    orderList = orderRepo.GetOrders();
                    ViewBag.Role = "Admin";
                }
                ViewBag.Message = TempData["Message"];
                return View(orderList);
            }
            else
            {
                TempData["Message"] = "You are not logging in!!! Back to login page!";
                return RedirectToAction("LoginPage", "Home");
            }
        }

        // GET: OrderController/Details/5
        public ActionResult Details(int id)
        {
            if (role != null)
            {
                var details = orderDetailRepo.GetDetailsByOrderId(id);
                if (role.StartsWith("MEMBER"))
                {
                    ViewBag.Role = "Member";
                }
                else
                {
                    ViewBag.Role = "Admin";
                }

                return View(details);
            }
            else
            {
                TempData["Message"] = "You are not logging in!!! Back to login page!";
                return RedirectToAction("LoginPage", "Home");
            }
            
        }
        // GET: OrderController/Delete/5
        public ActionResult Delete(int id)
        {
            if (role != null)
            {
                orderDetailRepo.DeleteDetailByOrderId(id);
                orderRepo.DeleteOrder(id);
                TempData["Message"] = "Remove Successfully!!!";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Message"] = "You are not logging in!!! Back to login page!";
                return RedirectToAction("LoginPage", "Home");
            }

        }
    }
}
