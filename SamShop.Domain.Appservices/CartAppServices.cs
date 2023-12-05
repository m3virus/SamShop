using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamShop.Domain.Core.Interfaces.AppServices;
using SamShop.Domain.Core.Interfaces.Services;
using SamShop.Domain.Core.Models.DtOs.CartDtOs;

namespace SamShop.Domain.Appservices
{
    public class CartAppServices : ICartAppServices
    {
        protected readonly ICartServices _cartServices;

        public CartAppServices(ICartServices cartServices)
        {
            _cartServices = cartServices;
        }


        public IEnumerable<CartDtOs> GetAllCart()
        {
            return _cartServices.GetAllCart();
        }

        public async Task<CartDtOs?> GetCartById(int id, CancellationToken cancellation)
        {
            return await _cartServices.GetCartById(id, cancellation);
        }

        public async Task<int> AddCart(CartDtOs Cart, CancellationToken cancellation)
        {
            return await _cartServices.AddCart(Cart, cancellation);
        }

        public async Task UpdateCart(CartDtOs Cart, CancellationToken cancellation)
        {
            await _cartServices.UpdateCart(Cart, cancellation);
        }

        public async Task DeleteCart(int id, CancellationToken cancellation)
        {
            await _cartServices.DeleteCart(id, cancellation);
        }

        public async Task<CartDtOs> GetCartByIsPayed(int customerId, CancellationToken cancellation)
        {
            return await _cartServices.GetCartByIsPayed(customerId, cancellation);
        }
    }
}
