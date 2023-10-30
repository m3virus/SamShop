using System;
using System.Collections.Generic;

namespace SamShop.Domain.Core.Models;

public partial class Seller
{
    public int SellerId { get; set; }

    public string UserName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public bool IsDeleted { get; set; }

    public virtual Address? Address { get; set; }

    public virtual ICollection<Auction> Auctions { get; set; } = new List<Auction>();

    public virtual Booth? Booth { get; set; }

    public virtual Medal? Medal { get; set; }

    public virtual Wallet Seller1 { get; set; } = null!;

    public virtual Picture SellerNavigation { get; set; } = null!;
}
