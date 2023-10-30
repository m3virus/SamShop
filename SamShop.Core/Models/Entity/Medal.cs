using System;
using System.Collections.Generic;

namespace SamShop.Domain.Core.Models.Entity;

public partial class Medal
{
    public int MedalId { get; set; }

    public string MedalType { get; set; } = null!;

    public decimal Wage { get; set; }

    public virtual Seller MedalNavigation { get; set; } = null!;
}
