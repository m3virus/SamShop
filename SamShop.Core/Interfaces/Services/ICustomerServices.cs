using SamShop.Domain.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamShop.Domain.Core.Models.DtOs.CustomerDtOs;

namespace SamShop.Domain.Core.Interfaces.Services
{
    public interface ICustomerServices
    {
        IEnumerable<CustomerDtOs> GetAllCustomer();
        Task<CustomerDtOs?> GetCustomerById(int id, CancellationToken cancellation);
        Task<int> AddCustomer(CustomerDtOs Customer, CancellationToken cancellation);
        Task UpdateCustomer(CustomerDtOs Customer, CancellationToken cancellation);
        Task DeleteCustomer(int id, CancellationToken cancellation);
        Task<CustomerDtOs> GetCustomerByAppUserId(int appId, CancellationToken cancellation);
    }
}
