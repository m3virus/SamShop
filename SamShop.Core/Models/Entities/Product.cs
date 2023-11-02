using System;
using System.Collections.Generic;

namespace SamShop.Domain.Core.Models.Entities;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public int CategoryId { get; set; }

    public int BoothId { get; set; }

    public decimal Price { get; set; }

    public bool IsDeleted { get; set; }

    public bool IsAccepted { get; set; }

    public bool IsAvailable { get; set; }

    public int Amount { get; set; }

    public virtual ICollection<Auction> Auctions { get; set; } = new List<Auction>();

    public virtual Booth Booth { get; set; } = null!;

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<Picture> Pictures { get; set; } = new List<Picture>();

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();
}
