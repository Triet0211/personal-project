using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class CartRepository : ICartRepository
    {
        public Cart AddToCart(ref Cart cart, int productId, int quantity) => CartDAO.Instance.AddToCart(ref cart, productId, quantity);
        public Cart RemoveFromCart(ref Cart cart, int productId) => CartDAO.Instance.RemoveFromCart(ref cart, productId);
        public Cart UpdateCart(ref Cart cart, int productId, int quantity) => CartDAO.Instance.UpdateCart(ref cart, productId, quantity);
        public void DeleteCart(ref Cart cart) => CartDAO.Instance.DeleteCart(ref cart);
    }
}
