using SamShop.Domain.Core.Models.DtOs.CustomerDtOs;
using SamShop.Domain.Core.Models.Entities;

namespace SamShop.Domain.Core.Interfaces.Repositories
{
    public interface ICustomerRepository
    {
        IEnumerable<CustomerDtOs> GetAllCustomer();
        Task<CustomerDtOs?> GetCustomerById(int id , CancellationToken cancellation);
        Task<int> AddCustomer(CustomerDtOs Customer, CancellationToken cancellation);
        Task UpdateCustomer(CustomerDtOs Customer , CancellationToken cancellation);
        Task DeleteCustomer(int id, CancellationToken cancellation);
    }
}
