using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SamShop.Domain.Core.Interfaces.Repositories;
using SamShop.Domain.Core.Models.Entities;
using SamShop.Infrastructure.EntityFramework.DBContext;

namespace SamShop.Infrastructure.DataAccess.Repositories
{
    public class WageRepository : IWageRepository
    {
        private readonly SamShopDbContext _context;

        public WageRepository(SamShopDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Wage> GetAllWage()
        {
            return _context.Wages;
        }

        public Task<Wage?> GetWageById(int id, CancellationToken cancellation)
        {
            return _context.Wages.FirstOrDefaultAsync(x => x.WageId == id, cancellation);
        }

        public async Task AddWage(Wage wage, CancellationToken cancellation)
        {
            Wage AddingWage = new Wage()
            {
                Price = wage.Price,
                PayTime = wage.PayTime,
                AdminId = wage.AdminId,
                SellerId = wage.SellerId,
                ProductId = wage.ProductId,
                DeleteTime = null,
                IsDeleted = false
            };
            await _context.AddAsync(AddingWage, cancellation);
            await _context.SaveChangesAsync(cancellation);
        }

        public async Task UpdateWage(Wage wage, CancellationToken cancellation)
        {
            Wage? UpdatingWage = await _context.Wages.FirstOrDefaultAsync(x => x.WageId == wage.WageId, cancellation);
            if (UpdatingWage != null)
            {
                UpdatingWage.Price = wage.Price;
                UpdatingWage.SellerId = wage.SellerId;
                UpdatingWage.ProductId = wage.ProductId;
            }

            await _context.SaveChangesAsync(cancellation);
        }

        public async Task DeleteWage(int id, CancellationToken cancellation)
        {
            Wage? removingWage = await _context.Wages.FirstOrDefaultAsync(x => x.WageId == id, cancellation);
            if (removingWage != null)
            {
                removingWage.IsDeleted = true;
                removingWage.DeleteTime = DateTime.Now;
            }

            await _context.SaveChangesAsync(cancellation);
        }
    }
}
