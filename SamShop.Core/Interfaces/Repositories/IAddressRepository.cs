using SamShop.Domain.Core.Models.Entities;

namespace SamShop.Domain.Core.Interfaces.Repositories
{
    public interface IAddressRepository
    {
        IEnumerable<Address> GetAllAddress();
        Task<Address?> GetAddressById(int id);
        Task AddAddress(Address Address);
        Task UpdateAddress(Address Address); 
        Task DeleteAddress(int id);
    }
}
