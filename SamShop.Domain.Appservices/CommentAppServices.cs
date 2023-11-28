using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamShop.Domain.Core.Interfaces.AppServices;
using SamShop.Domain.Core.Interfaces.Services;
using SamShop.Domain.Core.Models.DtOs.CommentDtOs;

namespace SamShop.Domain.Appservices
{
    public class CommentAppServices : ICommentAppServices
    {
        protected readonly ICommentServices _commentServices;

        public CommentAppServices(ICommentServices commentServices)
        {
            _commentServices = commentServices;
        }
        public IEnumerable<CommentDtOs> GetCommentByProduct(int productid)
        {
            return _commentServices.GetCommentByProduct(productid);
        }
        public async Task ConfirmComment(int commentId, CancellationToken cancellation)
        {
            await _commentServices.ConfirmComment(commentId, cancellation);
        }

        public async Task DeleteComment(int commentId, CancellationToken cancellation)
        {
            await _commentServices.DeleteComment(commentId, cancellation);
        }

        public IEnumerable<CommentDtOs> GetCommentsByIsAccepted()
        {
            return _commentServices.GetCommentsByIsAccepted();
        }

        public IEnumerable<CommentDtOs> GetAllComment()
        {
            return _commentServices.GetAllComment().Where(x => x.IsDeleted != true);
        }

        public async Task<CommentDtOs?> GetCommentById(int id, CancellationToken cancellation)
        {
            return await _commentServices.GetCommentById(id, cancellation);
        }

        public async Task<int> AddComment(CommentDtOs Comment, CancellationToken cancellation)
        {
            return await _commentServices.AddComment(Comment, cancellation);
        }

        public async Task UpdateComment(CommentDtOs Comment, CancellationToken cancellation)
        {
            await _commentServices.UpdateComment(Comment, cancellation);
        }
    }
}
