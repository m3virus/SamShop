using Microsoft.EntityFrameworkCore;
using SamShop.Domain.Core.Interfaces.Repositories;
using SamShop.Domain.Core.Models.Entities;
using SamShop.Infrastructure.EntityFramework.DBContext;

namespace SamShop.Infrastructure.DataAccess.Repositories
{
    internal class SellerRepository:ISellerRepository
    {
        protected readonly SamShopDbContext _context;

        public SellerRepository(SamShopDbContext context)
        {
            _context = context;
        }

        public async Task AddSeller(Seller Seller , CancellationToken cancellation)

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
                PictureId = Seller.PictureId,
                MedalId = Seller.MedalId,
                BoothId = Seller.BoothId,
                AddressId = Seller.AddressId,
                IsDeleted = false

            };
            await _context.Sellers.AddAsync(SellerAdding , cancellation) ;
            await _context.SaveChangesAsync(cancellation);
        }

        public IEnumerable<Seller> GetAllSeller()
        {
            return _context.Sellers;
        }



        public async Task<Seller?> GetSellerById(int id , CancellationToken cancellation)
        {
            return await _context.Sellers.FirstOrDefaultAsync(s => s.SellerId == id, cancellation);

        }

        public async Task UpdateSeller(Seller Seller , CancellationToken cancellation)
        {
            Seller? changeSeller =
                await _context.Sellers.FirstOrDefaultAsync(s => s.SellerId == Seller.SellerId, cancellation);
            if (changeSeller != null)
            {
                changeSeller.UserName = Seller.UserName;
                changeSeller.FirstName = Seller.FirstName;
                changeSeller.LastName = Seller.LastName;
                changeSeller.Wallet = Seller.Wallet;
                changeSeller.Password = Seller.Password;
                changeSeller.Email = Seller.Email;
                changeSeller.Phone = Seller.Phone;
                changeSeller.BoothId = Seller.BoothId;
                changeSeller.MedalId = Seller.MedalId;
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
            }

            await _context.SaveChangesAsync(cancellation);
        }
    }
}
