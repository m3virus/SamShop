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
    internal class AdminRepository : IAdminReository
    {
        protected readonly SamShopDbContext _context;

        public AdminRepository(SamShopDbContext context)
        {
            _context = context;
        }

        public async Task AddAdmin(Admin Admin)

        {
            Admin adminAdding = new Admin()
            {
               UserName = Admin.UserName,
               FirstName = Admin.FirstName,
               LastName = Admin.LastName,
               Phone = Admin.Phone,
               Email = Admin.Email,
               Wallet = Admin.Wallet,
               Password = Admin.Password,
               
            };
            await _context.Admins.AddAsync(adminAdding);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Admin> GetAllAdmin()
        {
            return _context.Admins;
        }



        public async Task<Admin?> GetAdminById(int id)
        {
            return await _context.Admins.FirstOrDefaultAsync(a => a.AdminId == id);

        }
        public async Task UpdateAdmin(Admin Admin)
        {
            Admin? changeAdmin = await _context.Admins.FirstOrDefaultAsync(p => p.AdminId == Admin.AdminId);
            if (changeAdmin != null)
            {
                changeAdmin.UserName = Admin.UserName;
                changeAdmin.FirstName = Admin.FirstName;
                changeAdmin.LastName = Admin.LastName;
                changeAdmin.Wallet = Admin.Wallet;
                changeAdmin.Password = Admin.Password;
                changeAdmin.Email = Admin.Email;
                changeAdmin.Phone = Admin.Phone;
            }

            await _context.SaveChangesAsync();
        }


        public async Task DeleteAdmin(int id)
        {
            Admin? removingaAdmin = await _context.Admins.FirstOrDefaultAsync(p => p.AdminId == id);
            if (removingaAdmin != null)
            {
                _context.Remove(removingaAdmin);
            }
            await _context.SaveChangesAsync();
        }
    }
}
