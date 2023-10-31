using System;
using System.Collections.Generic;

namespace SamShop.Domain.Core.Models.Entity;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public int BoothId { get; set; }

    public decimal Price { get; set; }

    public bool IsDeleted { get; set; }

    public bool IsAvailable { get; set; }

    public virtual Auction? Auction { get; set; }

    public virtual Booth Booth { get; set; } = null!;

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<Picture> Pictures { get; set; } = new List<Picture>();

    public virtual Category ProductNavigation { get; set; } = null!;

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();
}
