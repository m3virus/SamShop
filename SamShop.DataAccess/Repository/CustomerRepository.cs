using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SamShop.Application.EntityFramework.DBContext;
using SamShop.Domain.Core.Interfaces.IRepository;
using SamShop.Domain.Core.Models.Entity;

namespace SamShop.Application.DataAccess.Repository
{
    internal class CustomerRepository: ICustomerRepository
    {
        protected readonly SamShopDbContext _context;

        public CustomerRepository(SamShopDbContext context)
        {
            _context = context;
        }

        public async Task AddCustomer(Customer Customer)

        {
            Customer CustomerAdding = new Customer()
            {
                UserName = Customer.UserName,
                FirstName = Customer.FirstName,
                LastName = Customer.LastName,
                Phone = Customer.Phone,
                Email = Customer.Email,
                Wallet = Customer.Wallet,
                PasswordHash = Customer.PasswordHash

            };
            await _context.Customers.AddAsync(CustomerAdding);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Customer> GetAllCustomer()
        {
            return _context.Customers;
        }



        public async Task<Customer?> GetCustomerById(int id)
        {
            return await _context.Customers.FirstOrDefaultAsync(c => c.CustomerId == id);

        }

        public async Task UpdateCustomer(Customer Customer)
        {
            Customer? changeCustomer =
                await _context.Customers.FirstOrDefaultAsync(c => c.CustomerId == Customer.CustomerId);
            if (changeCustomer != null)
            {
                changeCustomer.UserName = Customer.UserName;
                changeCustomer.FirstName = Customer.FirstName;
                changeCustomer.LastName = Customer.LastName;
                changeCustomer.Wallet = Customer.Wallet;
                changeCustomer.PasswordHash = Customer.PasswordHash;
                changeCustomer.Email = Customer.Email;
                changeCustomer.Phone = Customer.Phone;
            }

            await _context.SaveChangesAsync();
        }


        public async Task DeleteCustomer(int id)
        {
            Customer? removingaCustomer = await _context.Customers.FirstOrDefaultAsync(c => c.CustomerId == id);
            if (removingaCustomer != null)
            {
                _context.Remove(removingaCustomer);
            }

            await _context.SaveChangesAsync();
        }
    }
}
