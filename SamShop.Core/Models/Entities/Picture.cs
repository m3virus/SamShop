using System;
using System.Collections.Generic;

namespace SamShop.Domain.Core.Models.Entities;

public partial class Picture
{
    public int PictureId { get; set; }

    public string Url { get; set; } 

    public int? ProductId { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime CreateTime { get; set; }

    public DateTime? DeleteTime { get; set; }

    public virtual Admin? Admin { get; set; } 

    public virtual Customer? Customer { get; set; } 

    public virtual Product? Product { get; set; }

    public virtual Seller? Seller { get; set; }
}
