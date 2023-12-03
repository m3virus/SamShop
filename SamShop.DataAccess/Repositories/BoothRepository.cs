using Microsoft.EntityFrameworkCore;
using SamShop.Domain.Core.Interfaces.Repositories;
using SamShop.Domain.Core.Models.DtOs.AdminDtOs;
using SamShop.Domain.Core.Models.DtOs.BoothDtOs;
using SamShop.Domain.Core.Models.Entities;
using SamShop.Infrastructure.EntityFramework.DBContext;

namespace SamShop.Infrastructure.DataAccess.Repositories
{
    public class BoothRepository : IBoothRepository
    {
        protected readonly SamShopDbContext _context;

        public BoothRepository(SamShopDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddBooth(BoothDtOs Booth, CancellationToken cancellation)

        {
            Booth BoothAdding = new Booth()
            {
                BoothId = Booth.BoothId,
                BoothName = Booth.BoothName,
                AddressId = Booth.AddressId,
                CreateTime = DateTime.Now,
                DeleteTime = null,
                IsDeleted = false,

            };
            await _context.Booths.AddAsync(BoothAdding, cancellation);
            await _context.SaveChangesAsync(cancellation);
            return BoothAdding.BoothId;
        }

        public IEnumerable<BoothDtOs> GetAllBooth()
        {
            var Booths = _context.Booths.Include(booth => booth.Seller)
                .ThenInclude(x => x.AppUser)
                .Include(booth => booth.Products)
                .ThenInclude(product => product.Category)
                .Include(booth => booth.Products)
                .ThenInclude(product => product.Pictures)
                .AsNoTracking();
            var boothDtOs = new List<BoothDtOs>();

            foreach (var a in Booths)
            {
                var booth = new BoothDtOs()
                {
                    BoothId = a.BoothId,
                    BoothName = a.BoothName,
                    AddressId = a.AddressId,
                    IsDeleted = a.IsDeleted,
                    CreateTime = a.CreateTime,
                    DeleteTime = a.DeleteTime, 
                    
                    Products = a.Products.Select(boothProduct => new Product
                    {
                        IsAccepted = boothProduct.IsAccepted,
                        IsDeleted = boothProduct.IsDeleted,
                        IsAvailable = boothProduct.IsAvailable,
                        ProductName = boothProduct.ProductName,
                        Price = boothProduct.Price,
                        Amount = boothProduct.Amount,
                        Pictures = boothProduct.Pictures.Select(picture => new Picture
                        {
                            Url = picture.Url
                        }).ToList(),
                        Category = new Category
                        {
                            CategoryName = boothProduct.Category.CategoryName,
                        }
                    }).ToList()
                };
                boothDtOs.Add(booth);
            }

            return boothDtOs;
        }



        public async Task<BoothDtOs?> GetBoothById(int id, CancellationToken cancellation)
        {
            var booth = await _context.Booths.AsNoTracking()
                .Include(b => b.Address)
                .Include(booth => booth.Products)
                    .ThenInclude(product => product.Category)
                .Include(booth => booth.Products)
                    .ThenInclude(product => product.Pictures)
                .FirstOrDefaultAsync(a => a.BoothId == id, cancellation);

            var boothById = new BoothDtOs()
            {
                BoothId = booth.BoothId,
                BoothName = booth.BoothName,
                AddressId = booth.AddressId,
                IsDeleted = booth.IsDeleted,
                CreateTime = booth.CreateTime,
                DeleteTime = booth.DeleteTime,

                Address = new Address
                {
                    Alley = booth.Address.Alley,
                    Street = booth.Address.Street,
                    City = booth.Address.City,
                    State = booth.Address.State,
                    ExtraPart = booth.Address.ExtraPart,
                    PostCode = booth.Address.PostCode,
                },
                Products = booth.Products.Select(boothProduct => new Product
                {
                    ProductId = boothProduct.ProductId,
                    ProductName = boothProduct.ProductName,
                    Price = boothProduct.Price,
                    Amount = boothProduct.Amount,
                    IsAccepted = boothProduct.IsAccepted,
                    IsDeleted = boothProduct.IsDeleted,
                    Category = new Category
                    {
                        CategoryName = boothProduct.Category.CategoryName,
                    },
                    Pictures = boothProduct.Pictures.Where(picture => picture.IsDeleted == false).Select(productPictures => new Picture
                    {
                        Url = productPictures.Url,
                    }).ToList(),
                }).ToList(),

            };
            return boothById;

        }
        public async Task UpdateBooth(BoothDtOs Booth, CancellationToken cancellation)
        {
            Booth? changeBooth = await _context.Booths
                .Include(Booth => Booth.Address)
                .Include(booth => booth.Products)
                    .ThenInclude(product => product.Category)
                .Include(booth => booth.Products)
                    .ThenInclude(product => product.Pictures)
                .FirstOrDefaultAsync(b => b.BoothId == Booth.BoothId, cancellation);
            if (changeBooth != null)
            {
                changeBooth.BoothName = Booth.BoothName;
                changeBooth.Address = new Address
                {
                    Alley = Booth.Address.Alley,
                    Street = Booth.Address.Street,
                    City = Booth.Address.City,
                    State = Booth.Address.State,
                    ExtraPart = Booth.Address.ExtraPart,
                    PostCode = Booth.Address.PostCode,
                };


            }

            await _context.SaveChangesAsync(cancellation);
        }


        public async Task DeleteBooth(int id, CancellationToken cancellation)
        {
            Booth? removingBooth = await _context.Booths.FirstOrDefaultAsync(b => b.BoothId == id, cancellation);
            if (removingBooth != null)
            {
                removingBooth.IsDeleted = true;
                removingBooth.DeleteTime = DateTime.Now;
            }
            await _context.SaveChangesAsync(cancellation);
        }
        
    }
}
