using System;
using System.Collections.Generic;

namespace SamShop.Domain.Core.Models.Entity;

public partial class Picture
{
    public int PictureId { get; set; }

    public string Url { get; set; } = null!;

    public int? ProductId { get; set; }

    public bool IsDeleted { get; set; }

    public int AdminId { get; set; }
    public virtual Admin? Admin { get; set; }

    public int CustomerId { get; set; }
    public virtual Customer? Customer { get; set; }

    
    public virtual Product? Product { get; set; }

    public int SellerId { get; set; }
    public virtual Seller? Seller { get; set; }
}
