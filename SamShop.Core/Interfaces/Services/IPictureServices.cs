using SamShop.Domain.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamShop.Domain.Core.Interfaces.Services
{
    public interface IPictureServices
    {
        IEnumerable<Picture> GetAllPicture();
        Task<Picture?> GetPictureById(int id, CancellationToken cancellation);
        Task AddPicture(Picture Picture, CancellationToken cancellation);
        Task UpdatePicture(Picture Picture, CancellationToken cancellation);
        Task DeletePicture(int id, CancellationToken cancellation);
    }
}
