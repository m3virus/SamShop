using SamShop.Domain.Core.Models.Entities;

namespace SamShop.Domain.Core.Interfaces.Repositories
{
    public interface IBoothRepository
    {
        IEnumerable<Booth> GetAllBooth(CancellationToken cancellation);
        Task<Booth?> GetBoothById(int id , CancellationToken cancellation);
        Task AddBooth(Booth Booth , CancellationToken cancellation);
        Task UpdateBooth(Booth Booth, CancellationToken cancellation);
        Task DeleteBooth(int id , CancellationToken cancellation);
    }
}
