using Microsoft.EntityFrameworkCore;
using SamShop.Domain.Core.Interfaces.Repositories;
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

        public async Task<int> AddPicture(Picture Picture, CancellationToken cancellation)

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

        public IEnumerable<Picture> GetAllPicture()
        {
            return _context.Pictures;
        }



        public async Task<Picture?> GetPictureById(int id, CancellationToken cancellation)
        {
            return await _context.Pictures.FirstOrDefaultAsync(p => p.PictureId == id, cancellation);

        }

        public async Task UpdatePicture(Picture Picture, CancellationToken cancellation)
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
