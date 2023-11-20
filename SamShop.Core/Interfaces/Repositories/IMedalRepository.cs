using SamShop.Domain.Core.Models.DtOs.MedalDtOs;
using SamShop.Domain.Core.Models.Entities;

namespace SamShop.Domain.Core.Interfaces.Repositories
{
    public interface IMedalRepository
    {
        IEnumerable<MedalDtOs> GetAllMedal();
        Task<MedalDtOs?> GetMedalById(int id, CancellationToken cancellation);
        Task<int> AddMedal(MedalDtOs Medal , CancellationToken cancellation);
        Task UpdateMedal(MedalDtOs Medal, CancellationToken cancellation);
        Task DeleteMedal(int id, CancellationToken cancellation);
    }
}
