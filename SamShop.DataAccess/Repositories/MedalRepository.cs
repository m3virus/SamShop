using Microsoft.EntityFrameworkCore;
using SamShop.Domain.Core.Interfaces.Repositories;
using SamShop.Domain.Core.Models.Entities;
using SamShop.Infrastructure.EntityFramework.DBContext;

namespace SamShop.Infrastructure.DataAccess.Repositories
{
    internal class MedalRepository:IMedalRepository
    {
        protected readonly SamShopDbContext _context;

        public MedalRepository(SamShopDbContext context)
        {
            _context = context;
        }

        public async Task AddMedal(Medal Medal , CancellationToken cancellation)

        {
            Medal MedalAdding = new Medal()
            {
                MedalType = Medal.MedalType,
                Wage = Medal.Wage,
                IsDeleted = false

            };
            await _context.Medals.AddAsync(MedalAdding , cancellation);
            await _context.SaveChangesAsync(cancellation);
        }

        public IEnumerable<Medal> GetAllMedal()
        {
            return _context.Medals;
        }



        public async Task<Medal?> GetMedalById(int id, CancellationToken cancellation)
        {
            return await _context.Medals.FirstOrDefaultAsync(m => m.MedalId == id, cancellation);

        }
        public async Task UpdateMedal(Medal Medal , CancellationToken cancellation)
        {
            Medal? changeMedal = await _context.Medals.FirstOrDefaultAsync(c => c.MedalId == Medal.MedalId, cancellation);
            if (changeMedal != null)
            {
                changeMedal.MedalType = Medal.MedalType;
                changeMedal.Wage = Medal.Wage;
            }

            await _context.SaveChangesAsync(cancellation);
        }


        public async Task DeleteMedal(int id, CancellationToken cancellation)
        {
            Medal? removingMedal = await _context.Medals.FirstOrDefaultAsync(c => c.MedalId == id , cancellation);
            if (removingMedal != null)
            {
                removingMedal.IsDeleted = true;
            }
            await _context.SaveChangesAsync(cancellation);
        }
    }
}
