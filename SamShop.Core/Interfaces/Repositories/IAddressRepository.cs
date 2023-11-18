using SamShop.Domain.Core.Models.Entities;


namespace SamShop.Domain.Core.Interfaces.Repositories
{
    public interface IAddressRepository
    {
        IEnumerable<Address> GetAllAddress();
        Task<Address?> GetAddressById(int id , CancellationToken cancellation);
        Task<int> AddAddress(Address Address , CancellationToken cancellation);
        Task UpdateAddress(Address Address , CancellationToken cancellation); 
        Task DeleteAddress(int id , CancellationToken cancellation);
    }
}
