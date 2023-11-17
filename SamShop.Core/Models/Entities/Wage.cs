using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamShop.Domain.Core.Models.Entities
{
    public class Wage
    {
        #region Entities

        public int WageId { get; set; }

        public int ProductId { get; set; }

        public int SellerId { get; set; }

        public int AdminId { get; set; }

        public decimal Price { get; set; }

        public DateTime PayTime { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeleteTime { get; set; }

        #endregion

        #region Navigations

        public virtual Product Product { get; set; }

        public virtual Seller Seller { get; set; }

        public virtual Admin Admin { get; set; }

        #endregion

    }
}
