using SamShop.Domain.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamShop.Domain.Core.Interfaces.Services
{
    public interface ICustomerServices
    {
        IEnumerable<Customer> GetAllCustomer();
        Task<Customer?> GetCustomerById(int id, CancellationToken cancellation);
        Task AddCustomer(Customer Customer, CancellationToken cancellation);
        Task UpdateCustomer(Customer Customer, CancellationToken cancellation);
        Task DeleteCustomer(int id, CancellationToken cancellation);
    }
}
