using System;
using System.Collections.Generic;

namespace SamShop.Domain.Core.Models;

public partial class AuctionOffer
{
    public int OfferId { get; set; }

    public decimal OfferValue { get; set; }

    public int AuctionId { get; set; }

    public int CustomerId { get; set; }

    public bool IsAccept { get; set; }

    public bool IsCanceled { get; set; }

    public virtual Auction Auction { get; set; } = null!;

    public virtual Customer Customer { get; set; } = null!;
}
