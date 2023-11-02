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
    internal class MedalRepository:IMedalRepository
    {
        protected readonly SamShopDbContext _context;

        public MedalRepository(SamShopDbContext context)
        {
            _context = context;
        }

        public async Task AddMedal(Medal Medal)

        {
            Medal MedalAdding = new Medal()
            {
                MedalType = Medal.MedalType,
                Wage = Medal.Wage,

            };
            await _context.Medals.AddAsync(MedalAdding);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Medal> GetAllMedal()
        {
            return _context.Medals;
        }



        public async Task<Medal?> GetMedalById(int id)
        {
            return await _context.Medals.FirstOrDefaultAsync(m => m.MedalId == id);

        }
        public async Task UpdateMedal(Medal Medal)
        {
            Medal? changeMedal = await _context.Medals.FirstOrDefaultAsync(c => c.MedalId == Medal.MedalId);
            if (changeMedal != null)
            {
                changeMedal.MedalType = Medal.MedalType;
                changeMedal.Wage = Medal.Wage;
            }

            await _context.SaveChangesAsync();
        }


        public async Task DeleteMedal(int id)
        {
            Medal? removingaMedal = await _context.Medals.FirstOrDefaultAsync(c => c.MedalId == id);
            if (removingaMedal != null)
            {
                _context.Remove(removingaMedal);
            }
            await _context.SaveChangesAsync();
        }
    }
}
