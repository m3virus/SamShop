using SamShop.Domain.Core.Models.Entities;

namespace SamShop.Domain.Core.Interfaces.Repositories
{
    public interface IAdminRepository
    {
        IEnumerable<Admin> GetAllAdmin();
        Task<Admin?> GetAdminById(int id , CancellationToken cancellation);
        Task<int> AddAdmin(Admin Admin , CancellationToken cancellation);
        Task UpdateAdmin(Admin Admin, CancellationToken cancellation);
        Task DeleteAdmin(int id , CancellationToken cancellation);
    }
}
