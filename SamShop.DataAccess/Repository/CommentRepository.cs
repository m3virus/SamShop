using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SamShop.Application.EntityFramework.DBContext;
using SamShop.Domain.Core.Interfaces.IRepository;
using SamShop.Domain.Core.Models.Entity;

namespace SamShop.Application.DataAccess.Repository
{
    internal class CommentRepository:ICommentRepository
    {
        protected readonly SamShopDbContext _context;

        public CommentRepository(SamShopDbContext context)
        {
            _context = context;
        }

        public async Task AddComment(Comment Comment)

        {
            Comment CommentAdding = new Comment()
            {
                Message = Comment.Message

            };
            await _context.Comments.AddAsync(CommentAdding);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Comment> GetAllComment()
        {
            return _context.Comments;
        }



        public async Task<Comment?> GetCommentById(int id)
        {
            return await _context.Comments.FirstOrDefaultAsync(c => c.CommentId == id);

        }
        public async Task UpdateComment(Comment Comment)
        {
            Comment? changeComment = await _context.Comments.FirstOrDefaultAsync(c => c.CommentId == Comment.CommentId);
            if (changeComment != null)
            {
                changeComment.Message = Comment.Message;
            }

            await _context.SaveChangesAsync();
        }


        public async Task DeleteComment(int id)
        {
            Comment? removingaComment = await _context.Comments.FirstOrDefaultAsync(c => c.CommentId == id);
            if (removingaComment != null)
            {
                _context.Remove(removingaComment);
            }
            await _context.SaveChangesAsync();
        }
    }
}
