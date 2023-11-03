﻿using Microsoft.EntityFrameworkCore;
using SamShop.Domain.Core.Interfaces.Repositories;
using SamShop.Domain.Core.Models.Entities;
using SamShop.Infrastructure.EntityFramework.DBContext;

namespace SamShop.Infrastructure.DataAccess.Repositories
{
    internal class CommentRepository:ICommentRepository
    {
        protected readonly SamShopDbContext _context;

        public CommentRepository(SamShopDbContext context)
        {
            _context = context;
        }

        public async Task AddComment(Comment Comment , CancellationToken cancellation)

        {
            Comment CommentAdding = new Comment()
            {
                Message = Comment.Message,
                ProductId = Comment.ProductId,
                CustomerId = Comment.CustomerId,
                IsAccepted = false,


            };
            await _context.Comments.AddAsync(CommentAdding , cancellation);
            await _context.SaveChangesAsync(cancellation);
        }

        public IEnumerable<Comment> GetAllComment()
        {
            return _context.Comments;
        }



        public async Task<Comment?> GetCommentById(int id , CancellationToken cancellation)
        {
            return await _context.Comments.FirstOrDefaultAsync(c => c.CommentId == id, cancellation);

        }
        public async Task UpdateComment(Comment Comment , CancellationToken cancellation)
        {
            Comment? changeComment = await _context.Comments.FirstOrDefaultAsync(c => c.CommentId == Comment.CommentId , cancellation);
            if (changeComment != null)
            {
                changeComment.Message = Comment.Message;
                changeComment.IsAccepted = Comment.IsAccepted;
            }

            await _context.SaveChangesAsync(cancellation);
        }


        public async Task DeleteComment(int id , CancellationToken cancellation)
        {
            Comment? removingComment = await _context.Comments.FirstOrDefaultAsync(c => c.CommentId == id, cancellation);
            if (removingComment != null)
            {
                _context.Remove(removingComment);
            }
            await _context.SaveChangesAsync(cancellation);
        }
    }
}
