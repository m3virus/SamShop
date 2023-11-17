using SamShop.Domain.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamShop.Domain.Core.Models.DtOs
{
    public class CommentDtOs
    {
        #region Entities

        public int CommentId { get; set; }

        public int ProductId { get; set; }

        public int CustomerId { get; set; }

        public bool IsAccepted { get; set; }

        public bool IsDeleted { get; set; }

        public string Message { get; set; }

        public DateTime? DeleteTime { get; set; }

        public DateTime CommentDate { get; set; }

        #endregion

        #region Navigations

        public virtual Customer Customer { get; set; }

        public virtual Product Product { get; set; }

        #endregion
    }
}
