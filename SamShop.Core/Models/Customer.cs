using System;
using System.Collections.Generic;

namespace SamShop.Domain.Core.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public bool IsDeleted { get; set; }

    public virtual ICollection<AuctionOffer> AuctionOffers { get; set; } = new List<AuctionOffer>();

    public virtual Cart? Cart { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual Wallet Customer1 { get; set; } = null!;

    public virtual Picture CustomerNavigation { get; set; } = null!;

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual ICollection<Address> AddressesNavigation { get; set; } = new List<Address>();
}
