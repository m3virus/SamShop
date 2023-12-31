﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamShop.Domain.Core.Models.DtOs.CommentDtOs;
using SamShop.Domain.Core.Models.Entities;

namespace SamShop.Domain.Core.Interfaces.Services
{
    public interface ICommentServices
    {
        Task ConfirmComment(int commentId, CancellationToken cancellation);
        Task DeleteComment(int commentId , CancellationToken cancellation);
        IEnumerable<CommentDtOs> GetCommentsByIsAccepted();
        IEnumerable<CommentDtOs> GetAllComment();
        IEnumerable<CommentDtOs> GetCommentByProduct(int productid);
        Task<CommentDtOs?> GetCommentById(int id, CancellationToken cancellation);
        Task<int> AddComment(CommentDtOs Comment, CancellationToken cancellation);
        Task UpdateComment(CommentDtOs Comment, CancellationToken cancellation);
        
    }
}
