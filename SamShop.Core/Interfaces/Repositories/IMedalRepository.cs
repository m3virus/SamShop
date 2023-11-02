using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamShop.Domain.Core.Models.Entity;

namespace SamShop.Domain.Core.Interfaces.IRepository
{
    public interface IMedalRepository
    {
        IEnumerable<Medal> GetAllMedal();
        Task<Medal?> GetMedalById(int id);
        Task AddMedal(Medal Medal);
        Task UpdateMedal(Medal Medal);
        Task DeleteMedal(int id);
    }
}
