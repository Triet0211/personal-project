using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        public void AddDetail(OrderDetail detail) => OrderDetailDAO.Instance.AddOrderDetail(detail);
        public void DeleteDetailByOrderId(int orderId) => OrderDetailDAO.Instance.DeleteOrderDetailByOrderId(orderId);
        public IEnumerable<OrderDetail> GetDetailsByOrderId(int orderId) => OrderDetailDAO.Instance.GetOrderDetailsByOrderId(orderId);
    }
}
