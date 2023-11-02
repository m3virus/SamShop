using Microsoft.EntityFrameworkCore;
using SamShop.Domain.Core.Interfaces.Repositories;
using SamShop.Domain.Core.Models.Entities;
using SamShop.Infrastructure.EntityFramework.DBContext;

namespace SamShop.Infrastructure.DataAccess.Repository
{
    internal class PictureRepository : IPictureRepository
    {
        
            protected readonly SamShopDbContext _context;

            public PictureRepository(SamShopDbContext context)
            {
                _context = context;
            }

            public async Task AddPicture(Picture Picture)

            {
                Picture PictureAdding = new Picture()
                {
                    Url = Picture.Url,
                    IsDeleted = false

                };
                await _context.Pictures.AddAsync(PictureAdding);
                await _context.SaveChangesAsync();
            }

            public IEnumerable<Picture> GetAllPicture()
            {
                return _context.Pictures;
            }



            public async Task<Picture?> GetPictureById(int id)
            {
                return await _context.Pictures.FirstOrDefaultAsync(p => p.PictureId == id);

            }

            public async Task UpdatePicture(Picture Picture)
            {
                Picture? changePicture =
                    await _context.Pictures.FirstOrDefaultAsync(p => p.PictureId == Picture.PictureId);
                if (changePicture != null)
                {
                    changePicture.Url = Picture.Url;
                }

                await _context.SaveChangesAsync();
            }


            public async Task DeletePicture(int id)
            {
                Picture? removingaPicture = await _context.Pictures.FirstOrDefaultAsync(p => p.PictureId == id);
                if (removingaPicture != null)
                {
                    _context.Remove(removingaPicture);
                }

                await _context.SaveChangesAsync();
            }
        }
    }
