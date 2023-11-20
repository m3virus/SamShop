using SamShop.Domain.Core.Models.DtOs.SellerDtOs;
using SamShop.Domain.Core.Models.Entities;

namespace SamShop.Domain.Core.Interfaces.Repositories
{
    public interface ISellerRepository
    {
        IEnumerable<SellerDtOs> GetAllSeller();
        Task<SellerDtOs?> GetSellerById(int id , CancellationToken cancellation);
        Task<int> AddSeller(SellerDtOs Seller , CancellationToken cancellation);
        Task UpdateSeller(SellerDtOs Seller , CancellationToken cancellation);
        Task DeleteSeller(int id, CancellationToken cancellation);
    }
}
