using Microsoft.EntityFrameworkCore;
using SamShop.Domain.Core.Interfaces.Repositories;
using SamShop.Domain.Core.Models.Entities;
using SamShop.Infrastructure.EntityFramework.DBContext;

namespace SamShop.Infrastructure.DataAccess.Repositories
{
    public class SellerRepository:ISellerRepository
    {
        protected readonly SamShopDbContext _context;

        public SellerRepository(SamShopDbContext context)
        {
            _context = context;
        }

        public async Task AddSeller(Seller Seller, CancellationToken cancellation)

        {
            Seller SellerAdding = new Seller()
            {
                
                Wallet = Seller.Wallet,
                PictureId = Seller.PictureId,
                MedalId = Seller.MedalId,
                BoothId = Seller.BoothId,
                AddressId = Seller.AddressId,
                IsDeleted = false,
                DeleteTime = null,
                CreateTime = DateTime.Now
                

            };
            await _context.Sellers.AddAsync(SellerAdding, cancellation);
            await _context.SaveChangesAsync(cancellation);
        }

        public IEnumerable<Seller> GetAllSeller()
        {
            return _context.Sellers;
        }



        public async Task<Seller?> GetSellerById(int id, CancellationToken cancellation)
        {
            return await _context.Sellers.FirstOrDefaultAsync(s => s.SellerId == id, cancellation);

        }

        public async Task UpdateSeller(Seller Seller, CancellationToken cancellation)
        {
            Seller? changeSeller =
                await _context.Sellers.FirstOrDefaultAsync(s => s.SellerId == Seller.SellerId, cancellation);
            if (changeSeller != null)
            {
                
                changeSeller.Wallet = Seller.Wallet;
                changeSeller.BoothId = Seller.BoothId;
                changeSeller.MedalId = 1;
                changeSeller.PictureId = Seller.PictureId;
                changeSeller.AddressId = Seller.AddressId;
            }

            await _context.SaveChangesAsync(cancellation);
        }


        public async Task DeleteSeller(int id, CancellationToken cancellation)
        {
            Seller? removingSeller = await _context.Sellers.FirstOrDefaultAsync(s => s.SellerId == id, cancellation);
            if (removingSeller != null)
            {
                removingSeller.IsDeleted = true;
                removingSeller.DeleteTime = DateTime.Now;
            }

            await _context.SaveChangesAsync(cancellation);
        }
    }
}
