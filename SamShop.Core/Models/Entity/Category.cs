using System;
using System.Collections.Generic;

namespace SamShop.Domain.Core.Models.Entity;

public partial class Category
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public bool IsDeleted { get; set; }

    public virtual Product? Product { get; set; }
}
