using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamShop.Domain.Core.Interfaces.AppServices;
using SamShop.Domain.Core.Interfaces.Services;
using SamShop.Domain.Core.Models.DtOs.CustomerDtOs;

namespace SamShop.Domain.Appservices
{
    public class CustomerAppServices : ICustomerAppServices
    {
        protected readonly ICustomerServices _customerServices;

        public CustomerAppServices(ICustomerServices customerServices)
        {
            _customerServices = customerServices;
        }

        public IEnumerable<CustomerDtOs> GetAllCustomer()
        {
            return _customerServices.GetAllCustomer();
        }

        public async Task<CustomerDtOs?> GetCustomerById(int id, CancellationToken cancellation)
        {
            return await _customerServices.GetCustomerById(id, cancellation);
        }

        public async Task<int> AddCustomer(CustomerDtOs Customer, CancellationToken cancellation)
        {
            return await _customerServices.AddCustomer(Customer, cancellation);
        }

        public async Task UpdateCustomer(CustomerDtOs Customer, CancellationToken cancellation)
        {
             await _customerServices.UpdateCustomer(Customer, cancellation);
        }

        public async Task DeleteCustomer(int id, CancellationToken cancellation)
        {
            await _customerServices.DeleteCustomer(id, cancellation);
        }

        public async Task<CustomerDtOs> GetCustomerByAppUserId(int appId, CancellationToken cancellation)
        {
            return await _customerServices.GetCustomerByAppUserId(appId, cancellation);
        }
    }
}
