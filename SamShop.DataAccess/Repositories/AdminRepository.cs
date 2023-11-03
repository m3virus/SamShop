using Microsoft.EntityFrameworkCore;
using SamShop.Domain.Core.Interfaces.Repositories;
using SamShop.Domain.Core.Models.Entities;
using SamShop.Infrastructure.EntityFramework.DBContext;

namespace SamShop.Infrastructure.DataAccess.Repositories
{
    internal class AdminRepository : IAdminReository
    {
        protected readonly SamShopDbContext _context;

        public AdminRepository(SamShopDbContext context)
        {
            _context = context;
        }

        public async Task AddAdmin(Admin Admin , CancellationToken cancellation)

        {
            Admin adminAdding = new Admin()
            {
               UserName = Admin.UserName,
               FirstName = Admin.FirstName,
               AddressId = Admin.AddressId,
               PictureId = Admin.PictureId,
               LastName = Admin.LastName,
               Phone = Admin.Phone,
               Email = Admin.Email,
               Wallet = Admin.Wallet,
               Password = Admin.Password,
               IsDeleted = false,
               
            };
            await _context.Admins.AddAsync(adminAdding , cancellation);
            await _context.SaveChangesAsync(cancellation);
        }

        

        public IEnumerable<Admin> GetAllAdmin()
        {
            return _context.Admins;
        }



        public async Task<Admin?> GetAdminById(int id, CancellationToken cancellation)
        {
            return await _context.Admins.FirstOrDefaultAsync(a => a.AdminId == id, cancellation);

        }
        public async Task UpdateAdmin(Admin Admin , CancellationToken cancellation)
        {
            Admin? changeAdmin = await _context.Admins.FirstOrDefaultAsync(p => p.AdminId == Admin.AdminId , cancellation);
            if (changeAdmin != null)
            {
                changeAdmin.UserName = Admin.UserName;
                changeAdmin.FirstName = Admin.FirstName;
                changeAdmin.LastName = Admin.LastName;
                changeAdmin.Wallet = Admin.Wallet;
                changeAdmin.Password = Admin.Password;
                changeAdmin.Email = Admin.Email;
                changeAdmin.Phone = Admin.Phone;
                changeAdmin.AddressId = Admin.AddressId;
                changeAdmin.PictureId = Admin.PictureId;
            }

            await _context.SaveChangesAsync(cancellation);
        }


        public async Task DeleteAdmin(int id , CancellationToken cancellation)
        {
            Admin? removingAdmin = await _context.Admins.FirstOrDefaultAsync(p => p.AdminId == id , cancellation);
            if (removingAdmin != null)
            {
                removingAdmin.IsDeleted = true;
            }
            await _context.SaveChangesAsync(cancellation);
        }
    }
}
