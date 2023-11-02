using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamShop.Domain.Core.Models.Entity;

namespace SamShop.Domain.Core.Interfaces.IRepository
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
