using System;
using System.Collections.Generic;

namespace SamShop.Domain.Core.Models;

public partial class Wallet
{
    public int WalletId { get; set; }

    public long Charge { get; set; }

    public virtual Admin? Admin { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual Seller? Seller { get; set; }
}
