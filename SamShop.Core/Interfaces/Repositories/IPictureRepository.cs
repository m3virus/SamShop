using SamShop.Domain.Core.Models.DtOs.PictureDtOs;
using SamShop.Domain.Core.Models.Entities;

namespace SamShop.Domain.Core.Interfaces.Repositories
{
    public interface IPictureRepository
    {
        IEnumerable<PictureDtOs> GetAllPicture();
        Task<PictureDtOs?> GetPictureById(int id , CancellationToken cancellation);
        Task<int> AddPicture(PictureDtOs Picture , CancellationToken cancellation);
        Task UpdatePicture(PictureDtOs Picture , CancellationToken cancellation);
        Task DeletePicture(int id , CancellationToken cancellation);
    }
}
