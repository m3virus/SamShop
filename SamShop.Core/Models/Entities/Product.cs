using System;
using System.Collections.Generic;

namespace SamShop.Domain.Core.Models.Entities;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } 

    public int CategoryId { get; set; }

    public int BoothId { get; set; }

    public decimal Price { get; set; }

    public bool IsDeleted { get; set; }

    public bool IsAccepted { get; set; }

    public bool IsAvailable { get; set; }

    public int Amount { get; set; }

    public DateTime AddTime { get; set; }

    public DateTime? DeleteTime { get; set; }

    public virtual ICollection<Auction> Auctions { get; set; } 

    public virtual Booth Booth { get; set; } 

    public virtual Category Category { get; set; } 

    public virtual ICollection<Comment> Comments { get; set; }

    public virtual ICollection<Picture> Pictures { get; set; } 

    public virtual ICollection<ProductCart> ProductCarts { get; set; } 

    public virtual Wage Wage { get; set; } 
}
