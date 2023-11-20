using SamShop.Domain.Core.Models.DtOs.PictureDtOs;
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
        IEnumerable<PictureDtOs> GetAllPicture();
        Task<PictureDtOs?> GetPictureById(int id, CancellationToken cancellation);
        Task<int> AddPicture(PictureDtOs Picture, CancellationToken cancellation);
        Task UpdatePicture(PictureDtOs Picture, CancellationToken cancellation);
        Task DeletePicture(int id, CancellationToken cancellation);
    }
}
