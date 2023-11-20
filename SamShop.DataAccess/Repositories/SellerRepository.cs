using Microsoft.EntityFrameworkCore;
using SamShop.Domain.Core.Interfaces.Repositories;
using SamShop.Domain.Core.Models.DtOs.SellerDtOs;
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

        public async Task<int> AddSeller(SellerDtOs Seller, CancellationToken cancellation)

        {
            Seller SellerAdding = new Seller()
            {
                
                Wallet = Seller.Wallet,
                PictureId = Seller.PictureId,
                MedalId = 1,
                BoothId = Seller.BoothId,
                AddressId = Seller.AddressId,
                AppUserId = Seller.AppUserId,
                IsDeleted = false,
                DeleteTime = null,
                CreateTime = DateTime.Now,
                

            };
            await _context.Sellers.AddAsync(SellerAdding, cancellation);
            await _context.SaveChangesAsync(cancellation);
            return SellerAdding.SellerId;
        }

        public IEnumerable<SellerDtOs> GetAllSeller()
        {
            var Sellers =  _context.Sellers.AsNoTracking();
            var SellerDtOs = new List<SellerDtOs>();

            foreach (var a in Sellers)
            {
                var Seller = new SellerDtOs()
                {
                    Wallet = a.Wallet,
                    PictureId = a.PictureId,
                    MedalId = a.MedalId,
                    BoothId = a.BoothId,
                    AddressId = a.AddressId,
                    AppUserId = a.AppUserId,
                    IsDeleted = a.IsDeleted,
                    DeleteTime = a.DeleteTime,
                    CreateTime = a.CreateTime,

                };
                SellerDtOs.Add(Seller);
            }

            return SellerDtOs;
        }



        public async Task<SellerDtOs?> GetSellerById(int id, CancellationToken cancellation)
        {
            var Seller = await _context.Sellers.AsNoTracking()
                .FirstOrDefaultAsync(a => a.SellerId == id, cancellation);

            var SellerById = new SellerDtOs()
            {

                Wallet = Seller.Wallet,
                PictureId = Seller.PictureId,
                MedalId = Seller.MedalId,
                BoothId = Seller.BoothId,
                AddressId = Seller.AddressId,
                AppUserId = Seller.AppUserId,
                IsDeleted = Seller.IsDeleted,
                DeleteTime = Seller.DeleteTime,
                CreateTime = Seller.CreateTime,
            };
            return SellerById; ;

        }

        public async Task UpdateSeller(SellerDtOs Seller, CancellationToken cancellation)
        {
            Seller? changeSeller =
                await _context.Sellers.FirstOrDefaultAsync(s => s.SellerId == Seller.SellerId, cancellation);
            if (changeSeller != null)
            {
                
                changeSeller.Wallet = Seller.Wallet;
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
                removingSeller.DeleteTime = DateTime.Now;
            }

            await _context.SaveChangesAsync(cancellation);
        }
    }
}
