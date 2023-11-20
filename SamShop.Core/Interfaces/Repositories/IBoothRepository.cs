using SamShop.Domain.Core.Models.DtOs.BoothDtOs;
using SamShop.Domain.Core.Models.Entities;

namespace SamShop.Domain.Core.Interfaces.Repositories
{
    public interface IBoothRepository
    {
        IEnumerable<BoothDtOs> GetAllBooth();
        Task<BoothDtOs?> GetBoothById(int id , CancellationToken cancellation);
        Task<int> AddBooth(BoothDtOs Booth , CancellationToken cancellation);
        Task UpdateBooth(BoothDtOs Booth, CancellationToken cancellation);
        Task DeleteBooth(int id , CancellationToken cancellation);
    }
}
