using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamShop.Domain.Core.Models.Entity;

namespace SamShop.Domain.Core.Interfaces.IRepository
{
    public interface IAddressRepository
    {
        IEnumerable<Address> GetAllAddress();
        Task<Address?> GetAddressById(int id);
        Task AddAddress(Address Address);
        Task UpdateAddress(Address Address); 
        Task DeleteAddress(int id);
    }
}
