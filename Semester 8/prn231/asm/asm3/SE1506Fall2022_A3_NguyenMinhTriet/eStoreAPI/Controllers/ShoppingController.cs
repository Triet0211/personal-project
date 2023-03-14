using BusinessObject;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace eStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingController : ControllerBase
    {
        private IProductRepository productRepo = new ProductRepository();
        private IMemberRepository memberRepo = new MemberRepository();
        private ICartRepository cartRepo = new CartRepository();
        private IOrderRepository orderRepo = new OrderRepository();
        private IOrderDetailRepository orderDetailRepo = new OrderDetailRepository();

        [HttpPost("remove/{productId}")]
        public ActionResult<Cart> RemoveFromCart(int productId, [FromBody] Cart cart)
        {
            try
            {
                return cartRepo.RemoveFromCart(ref cart, productId);
            } catch (Exception e)
            {
                return Problem(detail: e.Message);
            }
        }

        [HttpPost("add/{productId}/{quantity}")]
        public ActionResult<Cart> AddToCart(int productId, int quantity, [FromBody] Cart cart)
        {
            try
            {
                return cartRepo.AddToCart(ref cart, productId, quantity);
            }
            catch (Exception e)
            {
                return Problem(detail: e.Message);
            }
        }

        [HttpPost("update/{productId}/{quantity}")]
        public ActionResult<Cart> UpdateProductQuantityInCart(int productId, int quantity, [FromBody] Cart cart)
        {
            try
            {
                return cartRepo.UpdateCart(ref cart, productId, quantity);
            }
            catch (Exception e)
            {
                return Problem(detail: e.Message);
            }
        }

        [HttpPost("checkout/{memberId}")]
        public ActionResult CheckoutCart(string memberId, [FromBody] Cart cart)
        {
            try
            {
                eStoreUser mem = memberRepo.GetMemberByID(memberId);
                if (mem == null)
                {
                    throw new Exception("Member not found!");
                }
                bool check = true;
                foreach (var productInCart in cart.ListProduct)
                {
                    var productInStore = productRepo.GetProductByID(productInCart.ProductId);
                    if (productInCart.Quantity > productInStore.UnitsInStock)
                    {
                        check = false;
                        break;
                    }
                }
                if (check == true)
                {
                    Order order = new Order
                    {
                        OrderId = 0,
                        OrderDate = DateTime.Now,
                        MemberId = memberId,
                        RequiredDate = DateTime.Now.AddDays(5),
                        ShippedDate = DateTime.Now.AddDays(5),
                        Freight = 0
                    };
                    orderRepo.InsertOrder(order);
                    foreach (var productInCart in cart.ListProduct)
                    {
                        var productInStore = productRepo.GetProductByID(productInCart.ProductId);
                        productInStore.UnitsInStock = productInStore.UnitsInStock - productInCart.Quantity;
                        productRepo.UpdateProduct(productInStore);

                        IEnumerable<Order> listOrder = orderRepo.GetOrdersByMemebrId(memberId);
                        int currentId = listOrder.Max(ord => ord.OrderId);

                        OrderDetail currentDetail = new OrderDetail
                        {
                            OrderId = currentId,
                            ProductId = productInCart.ProductId,
                            UnitPrice = productInStore.UnitPrice,
                            Quantity = productInCart.Quantity,
                            Discount = 0
                        };
                        orderDetailRepo.AddDetail(currentDetail);
                    }
                    Cart tmp = cart;
                    cartRepo.DeleteCart(ref tmp);
                    return NoContent();
                } else
                {
                    throw new Exception("Your ordered quantity exceeds quantity in stock!!!");
                }
            }
            catch (Exception e)
            {
                return Problem(detail: e.Message);
            }
        }
    }
}
