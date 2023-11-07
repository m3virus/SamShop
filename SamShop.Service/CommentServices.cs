using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamShop.Domain.Core.Interfaces.Repositories;
using SamShop.Domain.Core.Interfaces.Services;
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

        public IEnumerable<Comment> GetCommentsByIsAccepted()
        {
            return _commentRepository.GetCommentByAccepted();
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
