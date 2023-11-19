﻿using Microsoft.EntityFrameworkCore;
using SamShop.Domain.Core.Interfaces.Repositories;
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

        public async Task<int> AddBooth(Booth Booth, CancellationToken cancellation)

        {
            Booth BoothAdding = new Booth()
            {
                BoothName = Booth.BoothName,
                AddressId = Booth.AddressId,
                CreateTime = DateTime.Now,
                DeleteTime = null

            };
            await _context.Booths.AddAsync(BoothAdding, cancellation);
            await _context.SaveChangesAsync(cancellation);
            return BoothAdding.BoothId;
        }

        public IEnumerable<Booth> GetAllBooth()
        {
            return _context.Booths;
        }



        public async Task<Booth?> GetBoothById(int id, CancellationToken cancellation)
        {
            var booth = await _context.Booths
                .Include(b => b.Address)
                .Include(b => b.Seller)
                    .ThenInclude(s => s.AppUser)
                .Include(b => b.Products)
                .FirstOrDefaultAsync(b => b.BoothId == id, cancellation);
            return booth;

        }
        public async Task UpdateBooth(Booth Booth, CancellationToken cancellation)
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
