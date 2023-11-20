using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamShop.Domain.Core.Interfaces.Repositories;
using SamShop.Domain.Core.Interfaces.Services;
using SamShop.Domain.Core.Models.DtOs.CustomerDtOs;
using SamShop.Domain.Core.Models.Entities;

namespace SamShop.Domain.Service
{
    public class CustomerServices: ICustomerServices

    {
        protected readonly ICustomerRepository _customerRepository;

        public CustomerServices(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public IEnumerable<CustomerDtOs> GetAllCustomer()
        {
            return _customerRepository.GetAllCustomer();
        }

        public async Task<CustomerDtOs?> GetCustomerById(int id, CancellationToken cancellation)
        {
            return await _customerRepository.GetCustomerById(id, cancellation);
        }

        public async Task<int> AddCustomer(CustomerDtOs Customer, CancellationToken cancellation)
        {
            return await _customerRepository.AddCustomer(Customer, cancellation);
        }

        public async Task UpdateCustomer(CustomerDtOs Customer, CancellationToken cancellation)
        {
            await _customerRepository.UpdateCustomer(Customer, cancellation);
        }

        public async Task DeleteCustomer(int id, CancellationToken cancellation)
        {
            await _customerRepository.DeleteCustomer(id, cancellation);
        }
    }
}
