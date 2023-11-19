using SamShop.Domain.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamShop.Domain.Core.Models.DtOs.AuctionDtOs
{
    public class AuctionDtOs
    {
        #region Entities

        public int AuctionId { get; set; }

        public int ProductId { get; set; }

        public int SellerId { get; set; }

        public string AuctionTitle { get; set; }

        public decimal TheLowestOffer { get; set; }

        public bool IsCanceled { get; set; }

        public bool IsAccepted { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public DateTime? CancelTime { get; set; }

        #endregion

        #region Navigations

        public virtual ICollection<AuctionOffer> AuctionOffers { get; set; }

        public virtual Product Product { get; set; }

        public virtual Seller Seller { get; set; }

        #endregion
    }
}
