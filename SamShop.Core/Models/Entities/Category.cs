using System;
using System.Collections.Generic;

namespace SamShop.Domain.Core.Models.Entities;

public partial class Category
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; }

    public bool IsAccepted { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? DeleteTime { get; set; }

    public DateTime CreateTime { get; set; }

    public virtual ICollection<Product> Products { get; set; } 
}
