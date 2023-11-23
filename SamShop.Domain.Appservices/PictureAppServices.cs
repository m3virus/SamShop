using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamShop.Domain.Core.Interfaces.AppServices;
using SamShop.Domain.Core.Interfaces.Services;
using SamShop.Domain.Core.Models.DtOs.PictureDtOs;

namespace SamShop.Domain.Appservices
{
    public class PictureAppServices:IPictureAppServices

    {
        protected readonly IPictureServices _pictureServices;

        public PictureAppServices(IPictureServices pictureServices)
        {
            _pictureServices = pictureServices;
        }

        public IEnumerable<PictureDtOs> GetAllPicture()
        {
            throw new NotImplementedException();
        }

        public async Task<PictureDtOs?> GetPictureById(int id, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public async Task<int> AddPicture(PictureDtOs Picture, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public async Task UpdatePicture(PictureDtOs Picture, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public async Task DeletePicture(int id, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }
    }
}
