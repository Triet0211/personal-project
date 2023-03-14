using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public interface ICartRepository
    {
        Cart AddToCart(ref Cart cart, int productId, int quantity);
        Cart RemoveFromCart(ref Cart cart, int productId);
        Cart UpdateCart(ref Cart cart, int productId, int quantity);
        void DeleteCart(ref Cart cart);
    }
}
