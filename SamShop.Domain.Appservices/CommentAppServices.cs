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

        public async Task ConfirmComment(int commentId, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteComment(int commentId, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CommentDtOs> GetCommentsByIsAccepted()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CommentDtOs> GetAllComment()
        {
            throw new NotImplementedException();
        }

        public async Task<CommentDtOs?> GetCommentById(int id, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public async Task<int> AddComment(CommentDtOs Comment, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateComment(CommentDtOs Comment, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }
    }
}
