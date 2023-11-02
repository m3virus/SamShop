using System;
using System.Collections.Generic;

namespace SamShop.Domain.Core.Models.Entities;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public decimal Wallet { get; set; }

    public string PasswordHash { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public int? PictureId { get; set; }

    public int AddressId { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Address Address { get; set; } = null!;

    public virtual ICollection<AuctionOffer> AuctionOffers { get; set; } = new List<AuctionOffer>();

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual Picture? Picture { get; set; }

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();
}
