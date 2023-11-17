using SamShop.Domain.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamShop.Domain.Core.Models.DtOs
{
    public class BoothDtOs
    {
        #region Entities

        public int BoothId { get; set; }

        public int AddressId { get; set; }

        public string BoothName { get; set; }

        public DateTime CreateTime { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeleteTime { get; set; }

        #endregion

        #region Navigations

        public virtual Address Address { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        public virtual Seller Seller { get; set; }

        #endregion
    }
}
