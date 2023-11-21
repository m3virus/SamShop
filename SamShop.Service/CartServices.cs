using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamShop.Domain.Core.Interfaces.Repositories;
using SamShop.Domain.Core.Interfaces.Services;
using SamShop.Domain.Core.Models.DtOs.CartDtOs;

namespace SamShop.Domain.Service
{
    public class CartServices : ICartServices
    {
        protected readonly ICartRepository _cartRepository;

        public CartServices(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public IEnumerable<CartDtOs> GetAllCart()
        {
            return _cartRepository.GetAllCart();
        }

        public async Task<CartDtOs?> GetCartById(int id, CancellationToken cancellation)
        {
            return await _cartRepository.GetCartById(id, cancellation);
        }

        public async Task<int> AddCart(CartDtOs Cart, CancellationToken cancellation)
        {
            return await _cartRepository.AddCart(Cart, cancellation);
        }

        public async Task UpdateCart(CartDtOs Cart, CancellationToken cancellation)
        {
            await _cartRepository.UpdateCart(Cart, cancellation);
        }

        public async Task DeleteCart(int id, CancellationToken cancellation)
        {
            await _cartRepository.DeleteCart(id, cancellation);
        }
    }
}
