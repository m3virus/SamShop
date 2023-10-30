using System;
using System.Collections.Generic;

namespace SamShop.Domain.Core.Models;

public partial class Booth
{
    public int BoothId { get; set; }

    public string BoothName { get; set; } = null!;

    public virtual Address? Address { get; set; }

    public virtual Seller BoothNavigation { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
