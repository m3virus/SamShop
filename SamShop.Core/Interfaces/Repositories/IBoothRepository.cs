using SamShop.Domain.Core.Models.Entities;

namespace SamShop.Domain.Core.Interfaces.Repositories
{
    public interface IBoothRepository
    {
        IEnumerable<Booth> GetAllBooth();
        Task<Booth?> GetBoothById(int id , CancellationToken cancellation);
        Task<int> AddBooth(Booth Booth , CancellationToken cancellation);
        Task UpdateBooth(Booth Booth, CancellationToken cancellation);
        Task DeleteBooth(int id , CancellationToken cancellation);
    }
}
