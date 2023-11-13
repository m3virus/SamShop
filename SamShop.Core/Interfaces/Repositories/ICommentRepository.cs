using SamShop.Domain.Core.Models.Entities;

namespace SamShop.Domain.Core.Interfaces.Repositories
{
    public interface ICommentRepository
    {
        IEnumerable<Comment> GetAllComment();
        Task<Comment?> GetCommentById(int id, CancellationToken cancellation);
        Task AddComment(Comment Comment , CancellationToken cancellation);
        Task UpdateComment(Comment Comment, CancellationToken cancellation);
        Task DeleteComment(int id , CancellationToken cancellation);
    }
}
