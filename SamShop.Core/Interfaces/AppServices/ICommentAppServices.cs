using SamShop.Domain.Core.Interfaces.Services;
using SamShop.Domain.Core.Models.DtOs.CommentDtOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamShop.Domain.Core.Interfaces.AppServices
{
    public interface ICommentAppServices
    {
        Task ConfirmComment(int commentId, CancellationToken cancellation);
        Task DeleteComment(int commentId, CancellationToken cancellation);
        IEnumerable<CommentDtOs> GetCommentsByIsAccepted();
        IEnumerable<CommentDtOs> GetCommentByProduct(int productid);
        IEnumerable<CommentDtOs> GetAllComment();
        Task<CommentDtOs?> GetCommentById(int id, CancellationToken cancellation);
        Task<int> AddComment(CommentDtOs Comment, CancellationToken cancellation);
        Task UpdateComment(CommentDtOs Comment, CancellationToken cancellation);
    }
}
