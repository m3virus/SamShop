using System;
using System.Collections.Generic;

namespace SamShop.Domain.Core.Models.Entities;

public partial class Seller
{
    public int SellerId { get; set; }

    public string UserName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public decimal Wallet { get; set; }

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public int BoothId { get; set; }

    public int MedalId { get; set; }

    public int? PictureId { get; set; }

    public int AddressId { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Address Address { get; set; } = null!;

    public virtual ICollection<Auction> Auctions { get; set; } = new List<Auction>();

    public virtual Booth Booth { get; set; } = null!;

    public virtual Medal Medal { get; set; } = null!;

    public virtual Picture? Picture { get; set; }
}
