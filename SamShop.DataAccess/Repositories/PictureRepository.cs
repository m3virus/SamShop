using Microsoft.EntityFrameworkCore;
using SamShop.Domain.Core.Interfaces.Repositories;
using SamShop.Domain.Core.Models.DtOs.PictureDtOs;
using SamShop.Domain.Core.Models.Entities;
using SamShop.Infrastructure.EntityFramework.DBContext;

namespace SamShop.Infrastructure.DataAccess.Repositories
{
    public class PictureRepository : IPictureRepository
    {

        protected readonly SamShopDbContext _context;

        public PictureRepository(SamShopDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddPicture(PictureDtOs Picture, CancellationToken cancellation)

        {
            Picture PictureAdding = new Picture()
            {
                Url = Picture.Url,
                ProductId = Picture.ProductId,
                IsDeleted = false,
                DeleteTime = null,
                CreateTime = DateTime.Now

            };
            await _context.Pictures.AddAsync(PictureAdding, cancellation);
            await _context.SaveChangesAsync(cancellation);
            return PictureAdding.PictureId;
        }

        public IEnumerable<PictureDtOs> GetAllPicture()
        {
            var Pictures = _context.Pictures.AsNoTracking();
            var PictureDtOs = new List<PictureDtOs>();

            foreach (var Picture in Pictures)
            {
                var a = new PictureDtOs()
                {
                    Url = Picture.Url,
                    ProductId = Picture.ProductId,
                    IsDeleted = Picture.IsDeleted,
                    DeleteTime = Picture.DeleteTime,
                    CreateTime = Picture.CreateTime

                };
                PictureDtOs.Add(a);
            }

            return PictureDtOs;
        }



        public async Task<PictureDtOs?> GetPictureById(int id, CancellationToken cancellation)
        {
            var Picture = await _context.Pictures.AsNoTracking()
                .FirstOrDefaultAsync(a => a.PictureId == id, cancellation);

            var PictureById = new PictureDtOs()
            {
                Url = Picture.Url,
                ProductId = Picture.ProductId,
                IsDeleted = Picture.IsDeleted,
                DeleteTime = Picture.DeleteTime,
                CreateTime = Picture.CreateTime

            };
            return PictureById;

        }

        public async Task UpdatePicture(PictureDtOs Picture, CancellationToken cancellation)
        {
            Picture? changePicture =
                await _context.Pictures.FirstOrDefaultAsync(p => p.PictureId == Picture.PictureId, cancellation);
            if (changePicture != null)
            {
                changePicture.Url = Picture.Url;
            }

            await _context.SaveChangesAsync(cancellation);
        }


        public async Task DeletePicture(int id, CancellationToken cancellation)
        {
            Picture? removingPicture = await _context.Pictures.FirstOrDefaultAsync(p => p.PictureId == id, cancellation);
            if (removingPicture != null)
            {
                removingPicture.IsDeleted = true;
                removingPicture.DeleteTime = DateTime.Now;
            }

            await _context.SaveChangesAsync(cancellation);
        }
        
    }
    }
