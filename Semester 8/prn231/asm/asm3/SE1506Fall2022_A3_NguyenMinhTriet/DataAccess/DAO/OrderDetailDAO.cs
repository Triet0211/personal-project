﻿using BusinessObject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    class OrderDetailDAO
    {
        // Using Singleton Pattern
        private static OrderDetailDAO instance = null;
        private static object instanceLock = new object();

        public static OrderDetailDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new OrderDetailDAO();
                    }
                    return instance;
                }
            }
        }
        public IEnumerable<OrderDetail> GetOrderDetailsByOrderId(int orderId)
        {
            var details = new List<OrderDetail>();

            try
            {
                using var context = new eStoreDbContext();
                details = context.OrderDetails.Where(d => d.OrderId == orderId).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return details;
        }
        public void AddOrderDetail(OrderDetail detail)
        {
            try
            {
                using var context = new eStoreDbContext();
                context.OrderDetails.Add(detail);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public void DeleteOrderDetailByOrderId(int orderId)
        {
            try
            {
                using var context = new eStoreDbContext();
                foreach (var detail in GetOrderDetailsByOrderId(orderId))
                {
                    var product = context.Products.SingleOrDefault(p => p.ProductId == detail.ProductId);
                    product.UnitsInStock += detail.Quantity;
                    context.Products.Update(product);
                    context.Remove(detail);
                }
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
