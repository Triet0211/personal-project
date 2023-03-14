using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PizzaShopWebApplication.Models;
using PizzaShopWebApplication.Utils;

namespace PizzaShopWebApplication.Pages.OrderManagement.Orders
{
    public class ReportsModel : PageModel
    {
        private readonly PizzaShopWebApplication.Models.NorthwindCopyDBContext _context;

        public ReportsModel(PizzaShopWebApplication.Models.NorthwindCopyDBContext context)
        {
            _context = context;
        }

        [BindProperty, DataType(DataType.Date)]
        public DateTime StartDate { get; set; } = DateTime.Now;
        [BindProperty, DataType(DataType.Date)]
        public DateTime EndDate { get; set; } = DateTime.Now;

        public decimal TotalPrice { get; set; } = 0;
        public bool _authorized
        {
            get
            {
                return CustomAuthorization.CheckRole("ADMIN");
            }
        }

        public IList<Order> Order { get;set; }

        public IActionResult OnGet()
        {
            if (!_authorized)
            {
                return Redirect("/Unauthorized");
            }
            Order = _context.Orders
                .Include(o => o.Customer).ToList();
            foreach (Order ord in Order)
            {
                TotalPrice += GetTotalPriceByOrderId(ord.OrderId);
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!_authorized)
            {
                return Redirect("/Unauthorized");
            }
            try
            {
                if (EndDate < StartDate)
                {
                    TempData["Message"] = "Please choose valid date!!!";
                    return Redirect("/OrderManagement/Orders/Reports");
                }
                else
                {
                    Tuple<IEnumerable<Order>, decimal> report = GetOrdersBetweenDate(StartDate, EndDate);
                    Order = report.Item1.ToList();
                    TotalPrice = report.Item2;
                    return Page();
                }
            } catch (Exception ex)
            {
                TempData["Message"] = "Something went wrong!!! Detail: " + ex.Message;
                return Redirect("/OrderManagement/Orders/Reports");
            }
        }
        public decimal GetTotalPriceByOrderId(string orderId)
        {
            decimal total = 0;
            try
            {
                foreach (var detail in _context.Orders.Find(orderId).OrderDetails)
                {
                    total += detail.UnitPrice * detail.Quantity;
                }
                total += _context.Orders.Find(orderId).Freight ?? 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return total;
        }

        public Tuple<IEnumerable<Order>, decimal> GetOrdersBetweenDate(DateTime startDate, DateTime endDate)
        {

            decimal totalPrice = 0;

            var orders = new List<Order>();
            try
            {
                //foreach (DateTime day in EachDay(startDate, endDate))
                //{
                //    IEnumerable<Order> OrderList = null;
                //    OrderList = _context.Orders.Where(o => o.OrderDate.GetValueOrDefault().Day == day.Day && o.OrderDate.GetValueOrDefault().Year == day.Year && o.OrderDate.GetValueOrDefault().Month == day.Month).OrderByDescending(o => o.OrderDate).ToList();
                //    orders.AddRange(OrderList);
                //}
                IEnumerable<Order> OrderList = _context.Orders.Where(o => o.OrderDate.Value.Date.CompareTo(StartDate.Date) >= 0 && o.OrderDate.Value.Date.CompareTo(EndDate.Date) <= 0).OrderByDescending(o => o.OrderDate).ToList();
                orders.AddRange(OrderList);
                foreach (Order ord in orders)
                {
                    totalPrice += GetTotalPriceByOrderId(ord.OrderId);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return new Tuple<IEnumerable<Order>, decimal>(orders, totalPrice);
        }

        public IEnumerable<DateTime> EachDay(DateTime from, DateTime thru)
        {
            for (var day = from.Date; day.Date <= thru.Date; day = day.AddDays(1))
                yield return day;
        }
    }
}
