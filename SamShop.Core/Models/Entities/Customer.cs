using System;
using System.Collections.Generic;

namespace SamShop.Domain.Core.Models.Entities;

public partial class Customer
{
    #region Entities

    public int CustomerId { get; set; }

    public decimal Wallet { get; set; }

    public int? PictureId { get; set; }

    public int AppUserId { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? DeleteTime { get; set; }

    public DateTime CreateTime { get; set; }

    #endregion

    #region MyRegion

    public virtual ICollection<AddressCustomer> AddressCustomers { get; set; }

    public virtual ICollection<AuctionOffer> AuctionOffers { get; set; }

    public virtual ICollection<Cart> Carts { get; set; }

    public virtual Comment Comment { get; set; }

    public virtual Picture? Picture { get; set; }

    public virtual AppUser? AppUser { get; set; }


    #endregion
}

