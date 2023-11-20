using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using SamShop.Domain.Core.Interfaces.Repositories;
using SamShop.Domain.Core.Models.DtOs.AdminDtOs;
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

        public async Task<int> AddAdmin(AdminDtOs Admin, CancellationToken cancellation)

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



        public IEnumerable<AdminDtOs> GetAllAdmin()
        {
            var Admin = _context.Admins.AsNoTracking();
            var adminDtOs = new List<AdminDtOs>();

             foreach (var a in Admin)
             {
                 var admin = new AdminDtOs()
                 {
                     AddressId = a.AddressId,
                     PictureId = a.PictureId,
                     Wallet = a.Wallet,
                     IsDeleted = a.IsDeleted,
                     CreateTime = a.CreateTime,
                     DeleteTime = a.DeleteTime,
                     AppUserId = a.AppUserId,
                 };
                 adminDtOs.Add(admin);
             }

             return adminDtOs;
        }



        public async Task<AdminDtOs?> GetAdminById(int id, CancellationToken cancellation)
        {
            var admin = await _context.Admins.AsNoTracking()
                .FirstOrDefaultAsync(a => a.AdminId == id, cancellation);

                var adminById = new AdminDtOs()
                {
                    AddressId = admin.AddressId,
                    PictureId = admin.PictureId,
                    Wallet = admin.Wallet,
                    IsDeleted = admin.IsDeleted,
                    CreateTime = admin.CreateTime,
                    DeleteTime = admin.DeleteTime,
                    AppUserId = admin.AppUserId,
                };
                return adminById;
            
        }
        public async Task UpdateAdmin(AdminDtOs Admin, CancellationToken cancellation)
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
