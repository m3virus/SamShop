using Microsoft.EntityFrameworkCore;
using SamShop.Domain.Core.Interfaces.Repositories;
using SamShop.Domain.Core.Models.DtOs.AdminDtOs;
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
                await _context.Sellers
                    .Include(s => s.Picture)
                    .Include(a => a.Address)
                    .FirstOrDefaultAsync(s => s.SellerId == Seller.SellerId, cancellation);
            if (changeSeller != null)
            {
                
                changeSeller.Wallet = Seller.Wallet;
                changeSeller.Address = new Address
                {
                    Alley = Seller.Address.Alley,
                    Street = Seller.Address.Street,
                    State = Seller.Address.State,
                    City = Seller.Address.City,
                    ExtraPart = Seller.Address.ExtraPart,
                    PostCode = Seller.Address.PostCode,
                };
                changeSeller.Picture = new Picture
                {
                    Url = Seller.Picture.Url,
                };


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
        public async Task<SellerDtOs> GetSellerByAppUserId(int appId, CancellationToken cancellation)
        {
            var Seller = await _context.Sellers.AsNoTracking()
                .Include(s => s.Picture)
                .Include(a => a.Address)
                .Include(s => s.Booth)
                    .ThenInclude(b =>b.Address)
                .Include(s => s.Booth)
                    .ThenInclude(b => b.Products)
                        .ThenInclude(p => p.Pictures)
                .Include(s => s.Booth)
                    .ThenInclude(b => b.Products)
                        .ThenInclude(p => p.Category)
                .Include(s => s.Auctions)
                .FirstOrDefaultAsync(a => a.AppUserId == appId, cancellation);

            var SellerByAppUserId = new SellerDtOs
            {
                SellerId = Seller.SellerId,

                Address = new Address()
                {
                    Alley = Seller.Address.Alley,
                    Street = Seller.Address.Street,
                    City = Seller.Address.City,
                    State = Seller.Address.State,
                    ExtraPart = Seller.Address.ExtraPart,
                    PostCode = Seller.Address.PostCode,
                },
                Picture = new Picture
                {
                    Url = Seller.Picture?.Url
                },
                Booth = new Booth
                {
                    BoothId = Seller.BoothId,
                    BoothName = Seller.Booth.BoothName,
                    Address = new Address
                    {
                        Alley = Seller.Booth.Address.Alley,
                        State = Seller.Booth.Address.State,
                        Street = Seller.Booth.Address.Street,
                        City = Seller.Booth.Address.City,
                        ExtraPart = Seller.Booth.Address.ExtraPart,
                        PostCode = Seller.Booth.Address.PostCode,
                    },
                    Products = Seller.Booth.Products.Select(boothProduct => new Product
                    {
                        ProductName = boothProduct.ProductName,
                        Price = boothProduct.Price,
                        Amount = boothProduct.Amount,
                        Pictures = boothProduct.Pictures.Select(productPicture => new Picture
                        {
                            Url = productPicture.Url,
                        }).ToList(),
                        Category = new Category
                        {
                            CategoryName = boothProduct.Category.CategoryName,
                        }
                    }).ToList()

                }
            };
            return SellerByAppUserId;
        }
    }
}
