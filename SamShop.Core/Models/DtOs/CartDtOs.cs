using SamShop.Domain.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamShop.Domain.Core.Models.DtOs
{
    public class CartDtOs
    {
        #region Entities

        public int CartId { get; set; }

        public decimal TotalPrice { get; set; }

        public int CustomerId { get; set; }

        public bool IsCanceled { get; set; }

        public bool IsPayed { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime? CancelTime { get; set; }

        #endregion

        #region Navigations

        public virtual Customer Customer { get; set; }

        public virtual ICollection<ProductCart> ProductCarts { get; set; }

        #endregion
    }
}
