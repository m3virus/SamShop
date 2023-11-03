using SamShop.Domain.Core.Models.Entities;

namespace SamShop.Domain.Core.Interfaces.Repositories
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAllCustomer(CancellationToken cancellation);
        Task<Customer?> GetCustomerById(int id , CancellationToken cancellation);
        Task AddCustomer(Customer Customer, CancellationToken cancellation);
        Task UpdateCustomer(Customer Customer , CancellationToken cancellation);
        Task DeleteCustomer(int id, CancellationToken cancellation);
    }
}
