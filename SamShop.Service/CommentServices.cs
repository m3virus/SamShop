using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamShop.Domain.Core.Interfaces.Repositories;
using SamShop.Domain.Core.Interfaces.Services;
using SamShop.Domain.Core.Models.DtOs.CommentDtOs;
using SamShop.Domain.Core.Models.Entities;

namespace SamShop.Domain.Service
{
    public class CommentServices : ICommentServices

    {
        private readonly ICommentRepository _commentRepository;
        
        public CommentServices(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public IEnumerable<CommentDtOs> GetCommentsByIsAccepted()
        {
            var Comments = _commentRepository.GetAllComment();
            return Comments.Where(c => c.IsAccepted !=true && c.IsDeleted != true);
        }

        public IEnumerable<CommentDtOs> GetAllComment()
        {
            return _commentRepository.GetAllComment();
        }

        public IEnumerable<CommentDtOs> GetCommentByProduct(int productid)
        {
            return _commentRepository.GetAllComment().Where(x => x.ProductId == productid && x.IsAccepted == true);
        }

        public async Task<CommentDtOs?> GetCommentById(int id, CancellationToken cancellation)
        {
            return await _commentRepository.GetCommentById(id, cancellation);
        }

        public async Task<int> AddComment(CommentDtOs Comment, CancellationToken cancellation)
        {
            return  await _commentRepository.AddComment(Comment, cancellation);
        }

        public async Task UpdateComment(CommentDtOs Comment, CancellationToken cancellation)
        {
            await _commentRepository.UpdateComment(Comment, cancellation);
        }

        public async Task ConfirmComment(int commentId, CancellationToken cancellation)
        {
            var result = await _commentRepository.GetCommentById(commentId , cancellation);
            result.IsAccepted = true;

            await _commentRepository.UpdateComment(result , cancellation);

        }

        public async Task DeleteComment(int commentId, CancellationToken cancellation)
        {
            await _commentRepository.DeleteComment(commentId, cancellation);

        }
    }
}
