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
            throw new NotImplementedException();
        }

        public async Task<CustomerDtOs?> GetCustomerById(int id, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public async Task<int> AddCustomer(CustomerDtOs Customer, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateCustomer(CustomerDtOs Customer, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteCustomer(int id, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }
    }
}
