using SamShop.Domain.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamShop.Domain.Core.Models.DtOs
{
    public class AdminDtOs
    {
        #region Entities

        public int AdminId { get; set; }

        public int AddressId { get; set; }

        public int? PictureId { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeleteTime { get; set; }

        public DateTime CreateTime { get; set; }

        public int AppUserId { get; set; }

        public decimal Wallet { get; set; }


        #endregion

        #region Navigations

        public virtual Address Address { get; set; }

        public virtual Picture? Picture { get; set; }

        public virtual AppUser Appuser { get; set; }

        public virtual ICollection<Wage> Wages { get; set; }

        #endregion
    }
}
