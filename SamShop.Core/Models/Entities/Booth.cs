using System;
using System.Collections.Generic;

namespace SamShop.Domain.Core.Models.Entities;

public partial class Booth
{
    public int BoothId { get; set; }

    public int AddressId { get; set; }

    public string BoothName { get; set; } 

    public DateTime CreateTime { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? DeleteTime { get; set; }

    public virtual Address Address { get; set; }

    public virtual ICollection<Product> Products { get; set; }

    public virtual Seller Seller { get; set; }
}
