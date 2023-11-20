using Microsoft.EntityFrameworkCore;
using SamShop.Domain.Core.Interfaces.Repositories;
using SamShop.Domain.Core.Models.DtOs.CustomerDtOs;
using SamShop.Domain.Core.Models.DtOs.CustomerDtOs;
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

        public async Task<int> AddCustomer(CustomerDtOs Customer, CancellationToken cancellation)

        {
            Customer CustomerAdding = new Customer()
            {
                
                Wallet = Customer.Wallet,
                PictureId = Customer.PictureId,
                AppUserId = Customer.AppUserId,
                CreateTime = DateTime.Now,
                IsDeleted = false,
                DeleteTime = null,


            };
            await _context.Customers.AddAsync(CustomerAdding, cancellation);
            await _context.SaveChangesAsync(cancellation);
            return CustomerAdding.CustomerId;
        }

        public IEnumerable<CustomerDtOs> GetAllCustomer()
        {
            var Customers = _context.Customers.AsNoTracking();
            var customerDtOs = new List<CustomerDtOs>();

            foreach (var a in Customers)
            {
                var customer = new CustomerDtOs()
                {
                    IsDeleted = a.IsDeleted,
                    DeleteTime = a.DeleteTime,
                    CustomerId = a.CustomerId,
                    AppUserId = a.AppUserId,
                    PictureId = a.PictureId,
                    Wallet = a.Wallet,
                    CreateTime = a.CreateTime,

                };
                customerDtOs.Add(customer);
            }

            return customerDtOs;
        }



        public async Task<CustomerDtOs?> GetCustomerById(int id, CancellationToken cancellation)
        {
            var Customer = await _context.Customers.AsNoTracking()
                .FirstOrDefaultAsync(a => a.CustomerId == id, cancellation);

            var CustomerById = new CustomerDtOs()
            {
                CreateTime = Customer.CreateTime,
                IsDeleted = Customer.IsDeleted,
                AppUserId = Customer.AppUserId,
                DeleteTime = Customer.DeleteTime,
                CustomerId = Customer.CustomerId,
                Wallet = Customer.Wallet,
                PictureId = Customer.PictureId
            };
            return CustomerById;
        }

        public async Task UpdateCustomer(CustomerDtOs Customer, CancellationToken cancellation)
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
