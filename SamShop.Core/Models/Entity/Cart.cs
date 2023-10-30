using System;
using System.Collections.Generic;

namespace SamShop.Domain.Core.Models.Entity;

public partial class Cart
{
    public int CartId { get; set; }

    public decimal TotalPrice { get; set; }

    public bool IsCanceled { get; set; }

    public bool IsPayed { get; set; }

    public virtual Customer CartNavigation { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
