using System;
using System.Collections.Generic;

namespace SamShop.Domain.Core.Models.Entity;

public partial class Price
{
    public int PriceId { get; set; }

    public decimal PriceAmount { get; set; }

    public DateTime? ChangeDate { get; set; }

    public int? ProductId { get; set; }

    public bool? IsDeleted { get; set; }
}
