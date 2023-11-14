using Microsoft.EntityFrameworkCore;
using SamShop.Domain.Core.Interfaces.Repositories;
using SamShop.Domain.Core.Models.Entities;
using SamShop.Infrastructure.EntityFramework.DBContext;

namespace SamShop.Infrastructure.DataAccess.Repositories
{
    public class AddressRepository : IAddressRepository 
    {
        protected readonly SamShopDbContext _context;

        public AddressRepository(SamShopDbContext context)
        {
            _context = context;
        }

        public async Task AddAddress(Address address, CancellationToken cancellation)

        {
            Address addressAdding = new Address()
            {
                State = address.State,
                City = address.City,
                Street = address.Street,
                Alley = address.Alley,
                ExtraPart = address.ExtraPart,
                PostCode = address.PostCode,
                
            };
            await _context.Addresses.AddAsync(addressAdding, cancellation);
            await _context.SaveChangesAsync(cancellation);
        }

        public IEnumerable<Address> GetAllAddress()
        {
            return _context.Addresses;
        }



        public async Task<Address?> GetAddressById(int id, CancellationToken cancellation)
        {
            return await _context.Addresses.FirstOrDefaultAsync(a => a.AddressId == id, cancellation);

        }
        public async Task UpdateAddress(Address address, CancellationToken cancellation)
        {
            Address? changeAddress = await _context.Addresses.FirstOrDefaultAsync(p => p.AddressId == address.AddressId, cancellation);
            if (changeAddress != null)
            {
                changeAddress.State = address.State;
                changeAddress.City = address.City;
                changeAddress.Street = address.Street;
                changeAddress.Alley = address.Alley;
                changeAddress.ExtraPart = address.ExtraPart;
                changeAddress.PostCode = address.PostCode;
            }

            await _context.SaveChangesAsync(cancellation);
        }


        public async Task DeleteAddress(int id, CancellationToken cancellation)
        {
            Address? removingAddress = await _context.Addresses.FirstOrDefaultAsync(p => p.AddressId == id, cancellation);
            if (removingAddress != null)
            {
                removingAddress.IsDeleted = true;
            }
            await _context.SaveChangesAsync(cancellation);
        }
        
    }
}
