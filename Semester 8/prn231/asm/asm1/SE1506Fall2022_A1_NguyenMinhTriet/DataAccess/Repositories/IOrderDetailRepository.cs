using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public interface IOrderDetailRepository
    {
        IEnumerable<OrderDetail> GetDetailsByOrderId(int orderId);
        void AddDetail(OrderDetail detail);
        void DeleteDetailByOrderId(int orderId);
    }
}