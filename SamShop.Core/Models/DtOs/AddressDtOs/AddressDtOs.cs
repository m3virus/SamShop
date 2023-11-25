using SamShop.Domain.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamShop.Domain.Core.Models.DtOs.AddressDtOs
{
    public class AddressDtOs
    {
        #region Entities

        public int AddressId { get; set; }

        public string State { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public string Alley { get; set; }

        public string ExtraPart { get; set; }

        public string PostCode { get; set; }

        public bool IsDeleted { get; set; }

        #endregion

        #region Navigations

        public virtual Admin? Admin { get; set; }
        public virtual Customer? Customer { get; set; }
        public virtual Seller? Seller { get; set; }
        public virtual Booth? Booth { get; set; }

        #endregion
    }
}
