using SamShop.Domain.Core.Models.DtOs.AddressDtOs;
using SamShop.Domain.Core.Models.Entities;


namespace SamShop.Domain.Core.Interfaces.Repositories
{
    public interface IAddressRepository
    {
        IEnumerable<AddressDtOs> GetAllAddress();
        Task<AddressDtOs?> GetAddressById(int id , CancellationToken cancellation);
        Task<int> AddAddress(AddressDtOs Address , CancellationToken cancellation);
        Task UpdateAddress(AddressDtOs Address , CancellationToken cancellation); 
        Task DeleteAddress(int id , CancellationToken cancellation);
    }
}
