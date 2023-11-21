using Microsoft.EntityFrameworkCore;
using SamShop.Domain.Core.Interfaces.Repositories;
using SamShop.Domain.Core.Models.DtOs.BoothDtOs;
using SamShop.Domain.Core.Models.DtOs.CommentDtOs;
using SamShop.Domain.Core.Models.Entities;
using SamShop.Infrastructure.EntityFramework.DBContext;

namespace SamShop.Infrastructure.DataAccess.Repositories
{
    public class CommentRepository:ICommentRepository
    {
        protected readonly SamShopDbContext _context;

        public CommentRepository(SamShopDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddComment(CommentDtOs Comment, CancellationToken cancellation)

        {
            Comment CommentAdding = new Comment()
            {
                Message = Comment.Message,
                ProductId = Comment.ProductId,
                CustomerId = Comment.CustomerId,
                IsAccepted = false,
                IsDeleted = false,
                DeleteTime = null,
                CommentDate = DateTime.Now
           };
            await _context.Comments.AddAsync(CommentAdding, cancellation);
            await _context.SaveChangesAsync(cancellation);
            return CommentAdding.CommentId;
        }

        public IEnumerable<CommentDtOs> GetAllComment()
        {
            var Comments = _context.Comments.AsNoTracking();
            var CommentDtOs = new List<CommentDtOs>();

            foreach (var a in Comments)
            {
                var Comment = new CommentDtOs()
                {
                    CommentId = a.CommentId,
                    Message = a.Message,
                    IsDeleted = a.IsDeleted,
                    DeleteTime = a.DeleteTime,
                    CustomerId = a.CustomerId,
                    IsAccepted = a.IsAccepted,
                    ProductId = a.ProductId,
                    CommentDate = a.CommentDate,

                };
                CommentDtOs.Add(Comment);
            }

            return CommentDtOs;

        }



        public async Task<CommentDtOs?> GetCommentById(int id, CancellationToken cancellation)
        {
            var Comment = await _context.Comments.AsNoTracking()
                .FirstOrDefaultAsync(a => a.CommentId == id, cancellation);

            var CommentById = new CommentDtOs()
            {
                CommentId = Comment.CommentId,
                Message = Comment.Message,
                IsDeleted = Comment.IsDeleted,
                CommentDate = Comment.CommentDate,
                DeleteTime = Comment.DeleteTime,
                CustomerId = Comment.CustomerId,
                ProductId = Comment.ProductId,
                IsAccepted = Comment.IsAccepted,
            };
            return CommentById;
        }
        public async Task UpdateComment(CommentDtOs Comment, CancellationToken cancellation)
        {
            Comment? changeComment = await _context.Comments.FirstOrDefaultAsync(c => c.CommentId == Comment.CommentId, cancellation);
            if (changeComment != null)
            {
                changeComment.Message = Comment.Message;
                changeComment.IsAccepted = Comment.IsAccepted;
            }

            await _context.SaveChangesAsync(cancellation);
        }


        public async Task DeleteComment(int id, CancellationToken cancellation)
        {
            Comment? removingComment = await _context.Comments.FirstOrDefaultAsync(c => c.CommentId == id, cancellation);
            if (removingComment != null)
            {
                removingComment.IsDeleted = true;
                removingComment.DeleteTime = DateTime.Now;
            }
            await _context.SaveChangesAsync(cancellation);
        }
        
    }
}
