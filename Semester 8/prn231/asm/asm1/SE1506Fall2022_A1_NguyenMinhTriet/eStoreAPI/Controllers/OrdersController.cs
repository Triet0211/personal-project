using BusinessObject;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace eStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        IOrderRepository orderRepo = new OrderRepository();
        IOrderDetailRepository orderDetailRepo = new OrderDetailRepository();

        [HttpPost("report")]
        public ActionResult<Tuple<IEnumerable<Order>, decimal>> Report ([FromBody] ReportPayload data)
        {
            try
            {
                DateTime startDate = data.StartDate + new TimeSpan(0, 0, 0);
                DateTime endDate = data.EndDate + new TimeSpan(23, 59, 59);
                Tuple<IEnumerable<Order>, decimal> report = orderRepo.GetOrdersBetweenDate(startDate, endDate);
                return report;
            }
            catch (Exception e)
            {
                return Problem(detail: e.Message);
            }
        }

        [HttpGet("member/{memberId}")]
        public ActionResult<IEnumerable<Order>> GetOrderList(int memberId)
        {
            try
            {
                if (memberId == 0)
                {
                    return orderRepo.GetOrders().ToList();
                } else
                {
                    return orderRepo.GetOrdersByMemebrId(memberId).ToList();
                }
            }
            catch (Exception e)
            {
                return Problem(detail: e.Message);
            }
        }

        [HttpGet("{orderId}")]
        public ActionResult<IEnumerable<OrderDetail>> GetOrderDetail(int orderId)
        {
            try
            {
                return orderDetailRepo.GetDetailsByOrderId(orderId).ToList();
            }
            catch (Exception e)
            {
                return Problem(detail: e.Message);
            }
        }

        [HttpDelete("{orderId}")]
        public ActionResult DeleteOrder(int orderId)
        {
            try
            {
                orderDetailRepo.DeleteDetailByOrderId(orderId);
                orderRepo.DeleteOrder(orderId);
                return NoContent();
            }
            catch (Exception e)
            {
                return Problem(detail: e.Message);
            }
        }
    }
}
