using BusinessObject;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    class OrderDAO
    {
        //Using Singleton Pattern
        private static OrderDAO instance = null;
        private static readonly object instanceLock = new object();
        private OrderDAO() { }
        public static OrderDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new OrderDAO();
                    }
                    return instance;
                }
            }
        }
        public IEnumerable<Order> GetOrderList()
        {
            var orders = new List<Order>();
            try
            {
                using var context = new FStoreDBContext();
                orders = context.Orders.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orders;
        }
        public Order GetOrderByID(int orderId)
        {
            Order order = null;
            try
            {
                using var context = new FStoreDBContext();
                order = context.Orders.SingleOrDefault(o => o.OrderId == orderId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return order;
        }
        public IEnumerable<Order> GetOrdersByMemberId(int memberId)
        {
            var orders = new List<Order>();
            try
            {
                using var context = new FStoreDBContext();
                orders = context.Orders.Where(o => o.MemberId == memberId).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orders;
        }
        public void AddNewOrder(Order order)
        {
            try
            {
                using var context = new FStoreDBContext();
                int maxOrderId = GetMaxOrderId();
                order.OrderId = maxOrderId + 1;
                context.Orders.Add(order);
                context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void UpdateOrder(Order order)
        {
            try
            {
                Order ord = GetOrderByID(order.OrderId);
                if (ord != null)
                {
                    using var context = new FStoreDBContext();
                    context.Orders.Update(order);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("This order is not found!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Remove(int orderId)
        {
            try
            {
                Order ord = GetOrderByID(orderId);
                if (ord != null)
                {
                    using var context = new FStoreDBContext();
                    context.Orders.Remove(ord);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("This order is not existed!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Tuple<IEnumerable<Order>, decimal> GetOrdersBetweenDate(DateTime startDate, DateTime endDate)
        {

            decimal? totalPrice = 0;

            var orders = new List<Order>();
            try
            {
                using var context = new FStoreDBContext();
                foreach (DateTime day in EachDay(startDate, endDate))
                {
                    IEnumerable<Order> OrderList = null;
                    OrderList = context.Orders.Where(o => o.OrderDate.Day == day.Day && o.OrderDate.Year == day.Year && o.OrderDate.Month == day.Month).OrderByDescending(o => o.OrderDate).ToList();
                    orders.AddRange(OrderList);
                }
                foreach (Order ord in orders)
                {
                    totalPrice += ord.Freight + GetTotalPriceByOrderId(ord.OrderId);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return new Tuple<IEnumerable<Order>, decimal>(orders, totalPrice ?? 0);
        }
        public IEnumerable<DateTime> EachDay(DateTime from, DateTime thru)
        {
            for (var day = from.Date; day.Date <= thru.Date; day = day.AddDays(1))
                yield return day;
        }
        public decimal? GetTotalPriceByOrderId(int orderId)
        {
            decimal? total = 0;
            try
            {
                using var context = new FStoreDBContext();
                var details = context.OrderDetails.Where(d => d.OrderId == orderId).ToList();

                foreach (var detail in details)
                {
                    total += detail.UnitPrice * detail.Quantity;
                }
                total += GetOrderByID(orderId).Freight;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return total;
        }

        public int GetMaxOrderId()
        {
            try
            {
                using var context = new FStoreDBContext();
                Order order = context.Orders.OrderByDescending(u => u.OrderId).FirstOrDefault();
                if (order == null)
                {
                    return 0;
                } else
                {
                    return order.OrderId;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}