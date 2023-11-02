using SamShop.Domain.Core.Models.Entities;

namespace SamShop.Domain.Core.Interfaces.Repositories
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
