using SamShop.Domain.Core.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamShop.Domain.Core.Interfaces.IRepository
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
