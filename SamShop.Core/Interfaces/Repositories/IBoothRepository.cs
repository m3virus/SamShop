using SamShop.Domain.Core.Models.Entities;

namespace SamShop.Domain.Core.Interfaces.Repositories
{
    public interface IBoothRepository
    {
        IEnumerable<Booth> GetAllBooth();
        Task<Booth?> GetBoothById(int id);
        Task AddBooth(Booth Booth);
        Task UpdateBooth(Booth Booth);
        Task DeleteBooth(int id);
    }
}
