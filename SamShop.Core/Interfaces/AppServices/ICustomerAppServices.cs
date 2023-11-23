using SamShop.Domain.Core.Models.DtOs.CustomerDtOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamShop.Domain.Core.Interfaces.AppServices
{
    public interface ICustomerAppServices
    {
        IEnumerable<CustomerDtOs> GetAllCustomer();
        Task<CustomerDtOs?> GetCustomerById(int id, CancellationToken cancellation);
        Task<int> AddCustomer(CustomerDtOs Customer, CancellationToken cancellation);
        Task UpdateCustomer(CustomerDtOs Customer, CancellationToken cancellation);
        Task DeleteCustomer(int id, CancellationToken cancellation);
    }
}
