using Microsoft.EntityFrameworkCore;
using SamShop.Domain.Core.Interfaces.Repositories;
using SamShop.Domain.Core.Models.DtOs.CartDtOs;
using SamShop.Domain.Core.Models.DtOs.CartDtOs;
using SamShop.Domain.Core.Models.Entities;
using SamShop.Infrastructure.EntityFramework.DBContext;

namespace SamShop.Infrastructure.DataAccess.Repositories
{
    public class CartRepository : ICartRepository
    {
        protected readonly SamShopDbContext _context;

        public CartRepository(SamShopDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddCart(CartDtOs Cart, CancellationToken cancellation)

        {
            Cart CartAdding = new Cart()
            {
                TotalPrice = Cart.TotalPrice,
                CustomerId = Cart.CustomerId,
                IsCanceled = false,
                IsPayed = false,
                CancelTime = null,
                CreateTime = DateTime.Now

            };
            await _context.Carts.AddAsync(CartAdding, cancellation);
            await _context.SaveChangesAsync(cancellation);
            return CartAdding.CartId;
        }

        public IEnumerable<CartDtOs> GetAllCart()
        {
            var Carts = _context.Carts.AsNoTracking();
            var CartDtOs = new List<CartDtOs>();

            foreach (var Cart in Carts)
            {
                var a = new CartDtOs()
                {
                    TotalPrice = Cart.TotalPrice,
                    CustomerId = Cart.CustomerId,
                    IsCanceled = Cart.IsCanceled,
                    IsPayed = Cart.IsPayed,
                    CancelTime = Cart.CancelTime,
                    CreateTime = Cart.CreateTime

                };
                CartDtOs.Add(a);
            }

            return CartDtOs;
        }



        public async Task<CartDtOs?> GetCartById(int id, CancellationToken cancellation)
        {
            var Cart = await _context.Carts.AsNoTracking()
                .FirstOrDefaultAsync(a => a.CartId == id, cancellation);

            var CartById = new CartDtOs()
            {
                TotalPrice = Cart.TotalPrice,
                CustomerId = Cart.CustomerId,
                IsCanceled = Cart.IsCanceled,
                IsPayed = Cart.IsPayed,
                CancelTime = Cart.CancelTime,
                CreateTime = Cart.CreateTime

            };
            return CartById;

        }
        public async Task UpdateCart(CartDtOs Cart, CancellationToken cancellation)
        {
            Cart? changeCart = await _context.Carts.FirstOrDefaultAsync(c => c.CartId == Cart.CartId, cancellation);
            if (changeCart != null)
            {
                changeCart.TotalPrice = Cart.TotalPrice;
                changeCart.IsCanceled = Cart.IsCanceled;
                changeCart.IsPayed = Cart.IsPayed;
                
            }

            await _context.SaveChangesAsync(cancellation);
        }


        public async Task DeleteCart(int id, CancellationToken cancellation)
        {
            Cart? removingCart = await _context.Carts.FirstOrDefaultAsync(c => c.CartId == id, cancellation);
            if (removingCart != null)
            {
                removingCart.IsCanceled = true;
                removingCart.CancelTime = DateTime.Now;
            }
            await _context.SaveChangesAsync(cancellation);
        }
        
    }
}
