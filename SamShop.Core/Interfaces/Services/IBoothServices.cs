using SamShop.Domain.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamShop.Domain.Core.Models.DtOs.BoothDtOs;

namespace SamShop.Domain.Core.Interfaces.Services
{
    public interface IBoothServices
    {
        IEnumerable<BoothDtOs> GetAllBooth();
        Task<BoothDtOs?> GetBoothById(int id, CancellationToken cancellation);
        Task<int> AddBooth(BoothDtOs Booth, CancellationToken cancellation);
        Task UpdateBooth(BoothDtOs Booth, CancellationToken cancellation);
        Task DeleteBooth(int id, CancellationToken cancellation);

    }
}
