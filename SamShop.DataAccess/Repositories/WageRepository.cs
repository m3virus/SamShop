using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SamShop.Domain.Core.Interfaces.Repositories;
using SamShop.Domain.Core.Models.DtOs.WageDtOs;
using SamShop.Domain.Core.Models.DtOs.WageDtOs;
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

        public IEnumerable<WageDtOs> GetAllWage()
        {
            var Wages =  _context.Wages.AsNoTracking();
            var WageDtOs = new List<WageDtOs>();

            foreach (var a in Wages)
            {
                var Wage = new WageDtOs()
                {
                    WageId = a.WageId,
                    ProductId = a.ProductId,
                    SellerId = a.SellerId,
                    Price = a.Price,
                    AdminId = a.AdminId,
                    IsDeleted = a.IsDeleted,
                    DeleteTime = a.DeleteTime,
                    PayTime = a.PayTime,

                };
                WageDtOs.Add(Wage);
            }

            return WageDtOs;
        }

        public async Task<WageDtOs?> GetWageById(int id, CancellationToken cancellation)
        {
            var Wage = await _context.Wages.AsNoTracking()
                .FirstOrDefaultAsync(a => a.WageId == id, cancellation);

            var WageById = new WageDtOs()
            {
                ProductId = Wage.ProductId,
                SellerId = Wage.SellerId,
                Price = Wage.Price,
                AdminId = Wage.AdminId,
                IsDeleted = Wage.IsDeleted,
                DeleteTime = Wage.DeleteTime,
                PayTime = Wage.PayTime,
            };
            return WageById; ;

        }

        public async Task<int> AddWage(WageDtOs wage, CancellationToken cancellation)
        {
            Wage AddingWage = new Wage()
            {
                Price = wage.Price,
                PayTime = null,
                AdminId = wage.AdminId,
                SellerId  = wage.SellerId,
                ProductId = wage.ProductId,
                DeleteTime = null,
                IsDeleted = false,
            };
            await _context.AddAsync(AddingWage, cancellation);
            await _context.SaveChangesAsync(cancellation);
            return AddingWage.WageId;
            
        }

        public async Task UpdateWage(WageDtOs wage, CancellationToken cancellation)
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
