using System;
using System.Collections.Generic;

namespace SamShop.Domain.Core.Models.Entities;

public partial class Booth
{
    public int BoothId { get; set; }

    public int AddressId { get; set; }

    public string BoothName { get; set; } = null!;

    public virtual Address Address { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual ICollection<Seller> Sellers { get; set; } = new List<Seller>();
}
