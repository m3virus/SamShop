using SamShop.Domain.Core.Models.Entities;

namespace SamShop.Domain.Core.Interfaces.Repositories
{
    public interface IPictureRepository
    {
        IEnumerable<Picture> GetAllPicture();
        Task<Picture?> GetPictureById(int id);
        Task AddPicture(Picture Picture);
        Task UpdatePicture(Picture Picture);
        Task DeletePicture(int id);
    }
}
