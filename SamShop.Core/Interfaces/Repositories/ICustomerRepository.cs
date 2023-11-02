using SamShop.Domain.Core.Models.Entities;

namespace SamShop.Domain.Core.Interfaces.Repositories
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAllCustomer();
        Task<Customer?> GetCustomerById(int id);
        Task AddCustomer(Customer Customer);
        Task UpdateCustomer(Customer Customer);
        Task DeleteCustomer(int id);
    }
}
