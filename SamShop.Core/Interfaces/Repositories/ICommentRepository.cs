using SamShop.Domain.Core.Models.Entities;

namespace SamShop.Domain.Core.Interfaces.Repositories
{
    public interface ICommentRepository
    {
        IEnumerable<Comment> GetAllComment();
        Task<Comment?> GetCommentById(int id);
        Task AddComment(Comment Comment);
        Task UpdateComment(Comment Comment);
        Task DeleteComment(int id);
    }
}
