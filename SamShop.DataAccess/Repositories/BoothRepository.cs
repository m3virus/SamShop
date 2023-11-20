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
            var Booths = _context.Booths.AsNoTracking();
            var boothDtOs = new List<BoothDtOs>();

            foreach (var a in Booths)
            {
                var booth = new BoothDtOs()
                {
                    BoothName = a.BoothName,
                    AddressId = a.AddressId,
                    IsDeleted = a.IsDeleted,
                    CreateTime = a.CreateTime,
                    DeleteTime = a.DeleteTime,
                    
                };
                boothDtOs.Add(booth);
            }

            return boothDtOs;
        }



        public async Task<BoothDtOs?> GetBoothById(int id, CancellationToken cancellation)
        {
            var booth = await _context.Booths.AsNoTracking()
                .FirstOrDefaultAsync(a => a.BoothId == id, cancellation);

            var boothById = new BoothDtOs()
            {
                AddressId = booth.AddressId,
               BoothName = booth.BoothName,
                IsDeleted = booth.IsDeleted,
                CreateTime = booth.CreateTime,
                DeleteTime = booth.DeleteTime,
            };
            return boothById;

        }
        public async Task UpdateBooth(BoothDtOs Booth, CancellationToken cancellation)
        {
            Booth? changeBooth = await _context.Booths.FirstOrDefaultAsync(b => b.BoothId == Booth.BoothId, cancellation);
            if (changeBooth != null)
            {
                changeBooth.BoothName = Booth.BoothName;
                changeBooth.AddressId = Booth.AddressId;
                
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
