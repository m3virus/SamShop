using SamShop.Domain.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamShop.Domain.Core.Models.DtOs.MedalDtOs
{
    public class MedalDtOs
    {
        #region Entities

        public int MedalId { get; set; }

        public string MedalType { get; set; }

        public bool IsDeleted { get; set; }

        public decimal WagePercentage { get; set; }

        public DateTime? DeleteTime { get; set; }

        public DateTime CreateTime { get; set; }

        #endregion

        #region Navigations

        public virtual Seller Seller { get; set; }

        #endregion
    }
}
