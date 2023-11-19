using SamShop.Domain.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamShop.Domain.Core.Models.DtOs.AuctionOfferDtOs
{
    public class AuctionOfferDtOs
    {
        #region Entiti

        public int OfferId { get; set; }

        public decimal OfferValue { get; set; }

        public int AuctionId { get; set; }

        public int CustomerId { get; set; }

        public bool IsAccept { get; set; }

        public bool IsCanceled { get; set; }

        public DateTime OfferTime { get; set; }

        public DateTime? CancelTime { get; set; }

        #endregion

        #region Navigations

        public virtual Auction Auction { get; set; } = null!;

        public virtual Customer Customer { get; set; } = null!;

        #endregion
    }
}
