using BusinessObject;
using System;
using System.Collections.Generic;

namespace DataAccess.Repository
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetOrders();
        Order GetOrderByID(int orderId);
        void InsertOrder(Order order);
        void DeleteOrder(int orderId);
        void UpdateOrder(Order order);
        IEnumerable<Order> GetOrdersByMemebrId(int memberId);
        Tuple<IEnumerable<Order>, decimal> GetOrdersBetweenDate(DateTime start, DateTime end);
    }
}
