using SamShop.Domain.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamShop.Domain.Core.Models.DtOs.SellerDtOs
{
    public class SellerDtOs
    {
        #region Entities

        public int SellerId { get; set; }

        public decimal Wallet { get; set; }
        public int MedalId { get; set; }

        public int? PictureId { get; set; }

        public int AddressId { get; set; }

        public int AppUserId { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeleteTime { get; set; }

        public DateTime CreateTime { get; set; }

        #endregion

        #region Navigations

        public virtual Address Address { get; set; }

        public virtual ICollection<Auction> Auctions { get; set; }

        public virtual Booth Booth { get; set; }

        public virtual Medal Medal { get; set; }

        public virtual Picture? Picture { get; set; }

        public virtual AppUser? AppUser { get; set; }

        public virtual ICollection<Wage> Wage { get; set; }

        #endregion

    }
}
