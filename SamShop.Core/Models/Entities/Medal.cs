using System;
using System.Collections.Generic;

namespace SamShop.Domain.Core.Models.Entities;

public partial class Medal
{
    public int MedalId { get; set; }

    public string MedalType { get; set; } = null!;

    public bool IsDeleted { get; set; }

    public decimal Wage { get; set; }

    public virtual ICollection<Seller> Sellers { get; set; } = new List<Seller>();
}
