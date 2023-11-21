using Microsoft.EntityFrameworkCore;
using SamShop.Domain.Core.Interfaces.Repositories;
using SamShop.Domain.Core.Models.DtOs.MedalDtOs;
using SamShop.Domain.Core.Models.Entities;
using SamShop.Infrastructure.EntityFramework.DBContext;

namespace SamShop.Infrastructure.DataAccess.Repositories
{
    public class MedalRepository:IMedalRepository
    {
        protected readonly SamShopDbContext _context;

        public MedalRepository(SamShopDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddMedal(MedalDtOs Medal, CancellationToken cancellation)

        {
            Medal MedalAdding = new Medal()
            {
                MedalType = Medal.MedalType,
                DeleteTime = null,
                IsDeleted = false,
                CreateTime = DateTime.Now,
                WagePercentage = Medal.WagePercentage

            };
            await _context.Medals.AddAsync(MedalAdding, cancellation);
            await _context.SaveChangesAsync(cancellation);
            return MedalAdding.MedalId;
        }

        public IEnumerable<MedalDtOs> GetAllMedal()
        {
            var Medals = _context.Medals.AsNoTracking();
            var MedalDtOs = new List<MedalDtOs>();

            foreach (var Medal in Medals)
            {
                var a = new MedalDtOs()
                {
                    MedalType = Medal.MedalType,
                    DeleteTime = Medal.DeleteTime,
                    IsDeleted = Medal.IsDeleted,
                    CreateTime = Medal.CreateTime,
                    WagePercentage = Medal.WagePercentage

                };
                MedalDtOs.Add(a);
            }

            return MedalDtOs;
        }



        public async Task<MedalDtOs?> GetMedalById(int id, CancellationToken cancellation)
        {
            var Medal = await _context.Medals.AsNoTracking()
                .FirstOrDefaultAsync(a => a.MedalId == id, cancellation);

            var MedalById = new MedalDtOs()
            {
                MedalType = Medal.MedalType,
                DeleteTime = Medal.DeleteTime,
                IsDeleted = Medal.IsDeleted,
                CreateTime = Medal.CreateTime,
                WagePercentage = Medal.WagePercentage
            };
            return MedalById;

        }
        public async Task UpdateMedal(MedalDtOs Medal, CancellationToken cancellation)
        {
            Medal? changeMedal = await _context.Medals.FirstOrDefaultAsync(c => c.MedalId == Medal.MedalId, cancellation);
            if (changeMedal != null)
            {
                changeMedal.MedalType = Medal.MedalType;
                changeMedal.WagePercentage = Medal.WagePercentage;
            }

            await _context.SaveChangesAsync(cancellation);
        }


        public async Task DeleteMedal(int id, CancellationToken cancellation)
        {
            Medal? removingMedal = await _context.Medals.FirstOrDefaultAsync(c => c.MedalId == id && id != 1, cancellation);
            if (removingMedal != null)
            {
                removingMedal.IsDeleted = true;
                removingMedal.DeleteTime = DateTime.Now;
            }
            await _context.SaveChangesAsync(cancellation);
        }
    }
}
