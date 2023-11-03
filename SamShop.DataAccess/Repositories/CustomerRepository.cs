using Microsoft.EntityFrameworkCore;
using SamShop.Domain.Core.Interfaces.Repositories;
using SamShop.Domain.Core.Models.Entities;
using SamShop.Infrastructure.EntityFramework.DBContext;

namespace SamShop.Infrastructure.DataAccess.Repositories
{
    internal class CustomerRepository: ICustomerRepository
    {
        protected readonly SamShopDbContext _context;

        public CustomerRepository(SamShopDbContext context)
        {
            _context = context;
        }

        public async Task AddCustomer(Customer Customer , CancellationToken cancellation)

        {
            Customer CustomerAdding = new Customer()
            {
                UserName = Customer.UserName,
                FirstName = Customer.FirstName,
                LastName = Customer.LastName,
                Phone = Customer.Phone,
                Email = Customer.Email,
                Wallet = Customer.Wallet,
                PasswordHash = Customer.PasswordHash,
                PictureId = Customer.PictureId,
                AddressId = Customer.AddressId,
                IsDeleted = false

            };
            await _context.Customers.AddAsync(CustomerAdding , cancellation);
            await _context.SaveChangesAsync(cancellation);
        }

        public IEnumerable<Customer> GetAllCustomer()
        {
            return _context.Customers;
        }



        public async Task<Customer?> GetCustomerById(int id , CancellationToken cancellation)
        {
            return await _context.Customers.FirstOrDefaultAsync(c => c.CustomerId == id, cancellation);

        }

        public async Task UpdateCustomer(Customer Customer, CancellationToken cancellation)
        {
            Customer? changeCustomer =
                await _context.Customers.FirstOrDefaultAsync(c => c.CustomerId == Customer.CustomerId, cancellation);
            if (changeCustomer != null)
            {
                changeCustomer.UserName = Customer.UserName;
                changeCustomer.FirstName = Customer.FirstName;
                changeCustomer.LastName = Customer.LastName;
                changeCustomer.Wallet = Customer.Wallet;
                changeCustomer.PasswordHash = Customer.PasswordHash;
                changeCustomer.Email = Customer.Email;
                changeCustomer.Phone = Customer.Phone;
                changeCustomer.AddressId = Customer.AddressId;
                changeCustomer.PictureId = Customer.PictureId;
            }

            await _context.SaveChangesAsync(cancellation);
        }


        public async Task DeleteCustomer(int id , CancellationToken cancellation)
        {
            Customer? removingCustomer = await _context.Customers.FirstOrDefaultAsync(c => c.CustomerId == id , cancellation);
            if (removingCustomer != null)
            {
                removingCustomer.IsDeleted = true;
            }

            await _context.SaveChangesAsync(cancellation);
        }
    }
}
