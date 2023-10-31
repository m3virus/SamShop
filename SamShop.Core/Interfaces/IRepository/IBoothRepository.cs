using SamShop.Domain.Core.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamShop.Domain.Core.Interfaces.IRepository
{
    public interface IBoothRepository
    {
        IEnumerable<Booth> GetAllBooth();
        Task<Booth?> GetBoothById(int id);
        Task AddBooth(Booth Booth);
        Task UpdateBooth(Booth Booth);
        Task DeleteBooth(int id);
    }
}
