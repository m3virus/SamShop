using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamShop.Domain.Core.Interfaces.Repositories;
using SamShop.Domain.Core.Interfaces.Services;
using SamShop.Domain.Core.Models.DtOs.PictureDtOs;

namespace SamShop.Domain.Service
{
    public class PictureServices : IPictureServices
    {
        protected readonly IPictureRepository _PictureRepository;

        public PictureServices(IPictureRepository PictureRepository)
        {
            _PictureRepository = PictureRepository;
        }

        public IEnumerable<PictureDtOs> GetAllPicture()
        {
            return _PictureRepository.GetAllPicture();
        }

        public async Task<PictureDtOs?> GetPictureById(int id, CancellationToken cancellation)
        {
            return await _PictureRepository.GetPictureById(id, cancellation);
        }

        public async Task<int> AddPicture(PictureDtOs Picture, CancellationToken cancellation)
        {
            return await _PictureRepository.AddPicture(Picture, cancellation);
        }

        public async Task UpdatePicture(PictureDtOs Picture, CancellationToken cancellation)
        {
            await _PictureRepository.UpdatePicture(Picture, cancellation);
        }

        public async Task DeletePicture(int id, CancellationToken cancellation)
        {
            await _PictureRepository.DeletePicture(id, cancellation);
        }
    }
}
