using Microsoft.EntityFrameworkCore;
using SamShop.Domain.Core.Interfaces.Repositories;
using SamShop.Domain.Core.Models.Entities;
using SamShop.Infrastructure.EntityFramework.DBContext;

namespace SamShop.Infrastructure.DataAccess.Repository
{
    internal class BoothRepository : IBoothRepository
    {
        protected readonly SamShopDbContext _context;

        public BoothRepository(SamShopDbContext context)
        {
            _context = context;
        }

        public async Task AddBooth(Booth Booth)

        {
            Booth BoothAdding = new Booth()
            {
                BoothName = Booth.BoothName

            };
            await _context.Booths.AddAsync(BoothAdding);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Booth> GetAllBooth()
        {
            return _context.Booths;
        }



        public async Task<Booth?> GetBoothById(int id)
        {
            return await _context.Booths.FirstOrDefaultAsync(b => b.BoothId == id);

        }
        public async Task UpdateBooth(Booth Booth)
        {
            Booth? changeBooth = await _context.Booths.FirstOrDefaultAsync(b => b.BoothId == Booth.BoothId);
            if (changeBooth != null)
            {
                changeBooth.BoothName = Booth.BoothName;
            }

            await _context.SaveChangesAsync();
        }


        public async Task DeleteBooth(int id)
        {
            Booth? removingaBooth = await _context.Booths.FirstOrDefaultAsync(b => b.BoothId == id);
            if (removingaBooth != null)
            {
                _context.Remove(removingaBooth);
            }
            await _context.SaveChangesAsync();
        }
    }
}
