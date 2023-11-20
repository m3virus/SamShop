using SamShop.Domain.Core.Models.DtOs.CommentDtOs;
using SamShop.Domain.Core.Models.Entities;

namespace SamShop.Domain.Core.Interfaces.Repositories
{
    public interface ICommentRepository
    {
        IEnumerable<CommentDtOs> GetAllComment();
        Task<CommentDtOs?> GetCommentById(int id, CancellationToken cancellation);
        Task<int> AddComment(CommentDtOs Comment , CancellationToken cancellation);
        Task UpdateComment(CommentDtOs Comment, CancellationToken cancellation);
        Task DeleteComment(int id , CancellationToken cancellation);
    }
}
