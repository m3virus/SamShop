using System;
using System.Collections.Generic;

namespace SamShop.Domain.Core.Models;

public partial class Auction
{
    public int AuctionId { get; set; }

    public string AuctionTitle { get; set; } = null!;

    public decimal TheLowestOffer { get; set; }

    public int SellerId { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public virtual Product AuctionNavigation { get; set; } = null!;

    public virtual ICollection<AuctionOffer> AuctionOffers { get; set; } = new List<AuctionOffer>();

    public virtual Seller Seller { get; set; } = null!;
}
