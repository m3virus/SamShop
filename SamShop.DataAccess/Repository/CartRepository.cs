using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SamShop.Application.EntityFramework.DBContext;
using SamShop.Domain.Core.Interfaces.IRepository;
using SamShop.Domain.Core.Models.Entity;

namespace SamShop.Application.DataAccess.Repository
{
    internal class CartRepository : ICartRepository
    {
        protected readonly SamShopDbContext _context;

        public CartRepository(SamShopDbContext context)
        {
            _context = context;
        }

        public async Task AddCart(Cart Cart)

        {
            Cart CartAdding = new Cart()
            {
                TotalPrice = Cart.TotalPrice,
                IsCanceled = false,
                IsPayed = false

            };
            await _context.Carts.AddAsync(CartAdding);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Cart> GetAllCart()
        {
            return _context.Carts;
        }



        public async Task<Cart?> GetCartById(int id)
        {
            return await _context.Carts.FirstOrDefaultAsync(c => c.CartId == id);

        }
        public async Task UpdateCart(Cart Cart)
        {
            Cart? changeCart = await _context.Carts.FirstOrDefaultAsync(c => c.CartId == Cart.CartId);
            if (changeCart != null)
            {
                changeCart.TotalPrice = Cart.TotalPrice;
                changeCart.IsCanceled = Cart.IsCanceled;
                changeCart.IsPayed = Cart.IsPayed;
            }

            await _context.SaveChangesAsync();
        }


        public async Task DeleteCart(int id)
        {
            Cart? removingaCart = await _context.Carts.FirstOrDefaultAsync(c => c.CartId == id);
            if (removingaCart != null)
            {
                _context.Remove(removingaCart);
            }
            await _context.SaveChangesAsync();
        }
    }
}
