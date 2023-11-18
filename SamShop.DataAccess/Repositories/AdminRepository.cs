using Microsoft.EntityFrameworkCore;
using SamShop.Domain.Core.Interfaces.Repositories;
using SamShop.Domain.Core.Models.Entities;
using SamShop.Infrastructure.EntityFramework.DBContext;

namespace SamShop.Infrastructure.DataAccess.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        protected readonly SamShopDbContext _context;

        public AdminRepository(SamShopDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddAdmin(Admin Admin, CancellationToken cancellation)

        {
            Admin adminAdding = new Admin()
            {
               AddressId = Admin.AddressId,
               PictureId = Admin.PictureId,
               AppUserId = Admin.AppUserId,
               IsDeleted = false,
               CreateTime = DateTime.Now,
               DeleteTime = null,
               Wallet = Admin.Wallet,
            };
            await _context.Admins.AddAsync(adminAdding, cancellation);
            await _context.SaveChangesAsync(cancellation);
            return adminAdding.AdminId;
        }



        public IEnumerable<Admin> GetAllAdmin()
        {
            return _context.Admins; 
        }



        public async Task<Admin?> GetAdminById(int id, CancellationToken cancellation)
        {
            return await _context.Admins.FirstOrDefaultAsync(a => a.AdminId == id, cancellation);

        }
        public async Task UpdateAdmin(Admin Admin, CancellationToken cancellation)
        {
            Admin? changeAdmin = await _context.Admins.FirstOrDefaultAsync(p => p.AdminId == Admin.AdminId, cancellation);
            if (changeAdmin != null)
            {
                changeAdmin.Wallet = Admin.Wallet;
                changeAdmin.PictureId = Admin.PictureId;
            }

            await _context.SaveChangesAsync(cancellation);
        }


        public async Task DeleteAdmin(int id, CancellationToken cancellation)
        {
            Admin? removingAdmin = await _context.Admins.FirstOrDefaultAsync(p => p.AdminId == id, cancellation);
            if (removingAdmin != null)
            {
                removingAdmin.IsDeleted = true;
                removingAdmin.DeleteTime = DateTime.Now;
            }
            await _context.SaveChangesAsync(cancellation);
        }
        
    }
}
