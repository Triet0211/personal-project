using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface ICartRepository
    {
        void AddToCart(ref Cart cart, int productId, int quantity);
        void RemoveFromCart(ref Cart cart, int productId);
        void UpdateCart(ref Cart cart, int productId, int quantity);
        void DeleteCart(ref Cart cart);
    }
}
