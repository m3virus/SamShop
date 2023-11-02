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
    internal class SellerRepository:ISellerRepository
    {
        protected readonly SamShopDbContext _context;

        public SellerRepository(SamShopDbContext context)
        {
            _context = context;
        }

        public async Task AddSeller(Seller Seller)

        {
            Seller SellerAdding = new Seller()
            {
                UserName = Seller.UserName,
                FirstName = Seller.FirstName,
                LastName = Seller.LastName,
                Phone = Seller.Phone,
                Email = Seller.Email,
                Wallet = Seller.Wallet,
                Password = Seller.Password,

            };
            await _context.Sellers.AddAsync(SellerAdding);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Seller> GetAllSeller()
        {
            return _context.Sellers;
        }



        public async Task<Seller?> GetSellerById(int id)
        {
            return await _context.Sellers.FirstOrDefaultAsync(s => s.SellerId == id);

        }

        public async Task UpdateSeller(Seller Seller)
        {
            Seller? changeSeller =
                await _context.Sellers.FirstOrDefaultAsync(s => s.SellerId == Seller.SellerId);
            if (changeSeller != null)
            {
                changeSeller.UserName = Seller.UserName;
                changeSeller.FirstName = Seller.FirstName;
                changeSeller.LastName = Seller.LastName;
                changeSeller.Wallet = Seller.Wallet;
                changeSeller.Password = Seller.Password;
                changeSeller.Email = Seller.Email;
                changeSeller.Phone = Seller.Phone;
            }

            await _context.SaveChangesAsync();
        }


        public async Task DeleteSeller(int id)
        {
            Seller? removingaSeller = await _context.Sellers.FirstOrDefaultAsync(s => s.SellerId == id);
            if (removingaSeller != null)
            {
                _context.Remove(removingaSeller);
            }

            await _context.SaveChangesAsync();
        }
    }
}
