using Microsoft.EntityFrameworkCore;
using SamShop.Domain.Core.Interfaces.Repositories;
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

        public async Task AddCart(Cart Cart , CancellationToken cancellation)

        {
            Cart CartAdding = new Cart()
            {
                TotalPrice = Cart.TotalPrice,
                CustomerId = Cart.CustomerId,
                IsCanceled = false,
                IsPayed = false

            };
            await _context.Carts.AddAsync(CartAdding , cancellation);
            await _context.SaveChangesAsync(cancellation);
        }

        public IEnumerable<Cart> GetAllCart()
        {
            return _context.Carts;
        }



        public async Task<Cart?> GetCartById(int id , CancellationToken cancellation)
        {
            return await _context.Carts.FirstOrDefaultAsync(c => c.CartId == id, cancellation);

        }
        public async Task UpdateCart(Cart Cart , CancellationToken cancellation)
        {
            Cart? changeCart = await _context.Carts.FirstOrDefaultAsync(c => c.CartId == Cart.CartId , cancellation);
            if (changeCart != null)
            {
                changeCart.TotalPrice = Cart.TotalPrice;
                changeCart.IsCanceled = Cart.IsCanceled;
                changeCart.IsPayed = Cart.IsPayed;
            }

            await _context.SaveChangesAsync(cancellation);
        }


        public async Task DeleteCart(int id , CancellationToken cancellation)
        {
            Cart? removingCart = await _context.Carts.FirstOrDefaultAsync(c => c.CartId == id, cancellation);
            if (removingCart != null)
            {
                removingCart.IsCanceled = true;
            }
            await _context.SaveChangesAsync(cancellation);
        }
    }
}
