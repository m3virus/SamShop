﻿using SamShop.Domain.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamShop.Domain.Core.Models.DtOs.CartDtOs;

namespace SamShop.Domain.Core.Interfaces.Services
{
    public interface ICartServices
    {
        IEnumerable<CartDtOs> GetAllCart();
        Task<CartDtOs?> GetCartById(int id, CancellationToken cancellation);
        Task<int> AddCart(CartDtOs Cart, CancellationToken cancellation);
        Task UpdateCart(CartDtOs Cart, CancellationToken cancellation);
        Task DeleteCart(int id, CancellationToken cancellation);
        Task<CartDtOs> GetCartByIsPayed(int customerId, CancellationToken cancellation);
        Task DeleteProductFromCart(int cartId, int productId, CancellationToken cancellation);
    }
}
