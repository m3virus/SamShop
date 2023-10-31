using SamShop.Domain.Core.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamShop.Domain.Core.Interfaces.IRepository
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
