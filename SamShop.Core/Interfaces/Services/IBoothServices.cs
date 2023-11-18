using SamShop.Domain.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamShop.Domain.Core.Interfaces.Services
{
    public interface IBoothServices
    {
        IEnumerable<Booth> GetAllBooth();
        Task<Booth?> GetBoothById(int id, CancellationToken cancellation);
        Task<int> AddBooth(Booth Booth, CancellationToken cancellation);
        Task UpdateBooth(Booth Booth, CancellationToken cancellation);
        Task DeleteBooth(int id, CancellationToken cancellation);
    }
}
