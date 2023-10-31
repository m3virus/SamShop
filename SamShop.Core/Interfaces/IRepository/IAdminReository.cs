using SamShop.Domain.Core.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamShop.Domain.Core.Interfaces.IRepository
{
    public interface IAdminReository
    {
        IEnumerable<Admin> GetAllAdmin();
        Task<Admin?> GetAdminById(int id);
        Task AddAdmin(Admin Admin);
        Task UpdateAdmin(Admin Admin);
        Task DeleteAdmin(int id);
    }
}
