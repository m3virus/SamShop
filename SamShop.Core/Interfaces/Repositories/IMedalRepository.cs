﻿using SamShop.Domain.Core.Models.Entities;

namespace SamShop.Domain.Core.Interfaces.Repositories
{
    public interface IMedalRepository
    {
        IEnumerable<Medal> GetAllMedal(CancellationToken cancellation);
        Task<Medal?> GetMedalById(int id, CancellationToken cancellation);
        Task AddMedal(Medal Medal , CancellationToken cancellation);
        Task UpdateMedal(Medal Medal, CancellationToken cancellation);
        Task DeleteMedal(int id, CancellationToken cancellation);
    }
}
