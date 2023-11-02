using SamShop.Domain.Core.Models.Entities;

namespace SamShop.Domain.Core.Interfaces.Repositories
{
    public interface IMedalRepository
    {
        IEnumerable<Medal> GetAllMedal();
        Task<Medal?> GetMedalById(int id);
        Task AddMedal(Medal Medal);
        Task UpdateMedal(Medal Medal);
        Task DeleteMedal(int id);
    }
}
