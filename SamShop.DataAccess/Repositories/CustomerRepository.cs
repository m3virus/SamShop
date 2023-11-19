using Microsoft.EntityFrameworkCore;
using SamShop.Domain.Core.Interfaces.Repositories;
using SamShop.Domain.Core.Models.Entities;
using SamShop.Infrastructure.EntityFramework.DBContext;

namespace SamShop.Infrastructure.DataAccess.Repositories
{
    public class CustomerRepository: ICustomerRepository
    {
        protected readonly SamShopDbContext _context;

        public CustomerRepository(SamShopDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddCustomer(Customer Customer, CancellationToken cancellation)

        {
            Customer CustomerAdding = new Customer()
            {
                
                Wallet = Customer.Wallet,
                PictureId = Customer.PictureId,
                AppUserId = Customer.AppUserId

            };
            await _context.Customers.AddAsync(CustomerAdding, cancellation);
            await _context.SaveChangesAsync(cancellation);
            return CustomerAdding.CustomerId;
        }

        public IEnumerable<Customer> GetAllCustomer()
        {
            return _context.Customers;
        }



        public async Task<Customer?> GetCustomerById(int id, CancellationToken cancellation)
        {
            var customer = await _context.Customers
                .Include(c => c.AppUser)
                .Include(a => a.Picture)
                .Include(c => c.AddressCustomers)
                    .ThenInclude(a => a.Address)
                .FirstOrDefaultAsync(c => c.CustomerId == id, cancellation);
            return customer;
        }

        public async Task UpdateCustomer(Customer Customer, CancellationToken cancellation)
        {
            Customer? changeCustomer =
                await _context.Customers.FirstOrDefaultAsync(c => c.CustomerId == Customer.CustomerId, cancellation);
            if (changeCustomer != null)
            {
               changeCustomer.PictureId = Customer.PictureId;
               changeCustomer.Wallet = Customer.Wallet;
            }

            await _context.SaveChangesAsync(cancellation);
        }


        public async Task DeleteCustomer(int id, CancellationToken cancellation)
        {
            Customer? removingCustomer = await _context.Customers.FirstOrDefaultAsync(c => c.CustomerId == id, cancellation);
            if (removingCustomer != null)
            {
                removingCustomer.IsDeleted = true;
                removingCustomer.DeleteTime = DateTime.Now;
            }

            await _context.SaveChangesAsync(cancellation);
        }
        
    }
}
