using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class OrderRepository : IOrderRepository
    {
        public IEnumerable<Order> GetOrders() => OrderDAO.Instance.GetOrderList();
        public Order GetOrderByID(int orderId) => OrderDAO.Instance.GetOrderByID(orderId);
        public void InsertOrder(Order order) => OrderDAO.Instance.AddNewOrder(order);
        public void DeleteOrder(int orderId) => OrderDAO.Instance.Remove(orderId);
        public void UpdateOrder(Order order) => OrderDAO.Instance.UpdateOrder(order);
        public IEnumerable<Order> GetOrdersByMemebrId(int memberId) => OrderDAO.Instance.GetOrdersByMemberId(memberId);
        public Tuple<IEnumerable<Order>, decimal> GetOrdersBetweenDate(DateTime start, DateTime end) => OrderDAO.Instance.GetOrdersBetweenDate(start, end);
    }
}
