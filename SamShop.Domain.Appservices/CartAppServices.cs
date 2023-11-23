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
            throw new NotImplementedException();
        }

        public async Task<CartDtOs?> GetCartById(int id, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public async Task<int> AddCart(CartDtOs Cart, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateCart(CartDtOs Cart, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteCart(int id, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }
    }
}
