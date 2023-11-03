using SamShop.Domain.Core.Models.Entities;

namespace SamShop.Domain.Core.Interfaces.Repositories
{
    public interface IPictureRepository
    {
        IEnumerable<Picture> GetAllPicture(CancellationToken cancellation);
        Task<Picture?> GetPictureById(int id , CancellationToken cancellation);
        Task AddPicture(Picture Picture , CancellationToken cancellation);
        Task UpdatePicture(Picture Picture , CancellationToken cancellation);
        Task DeletePicture(int id , CancellationToken cancellation);
    }
}
