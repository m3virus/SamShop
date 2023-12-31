﻿using System;
using System.Collections.Generic;

namespace SamShop.Domain.Core.Models.Entities;

public partial class Cart
{
    #region Entities

    public int CartId { get; set; }

    public decimal TotalPrice { get; set; }

    public int CustomerId { get; set; }

    public bool IsCanceled { get; set; }

    public bool IsPayed { get; set; }

    public DateTime CreateTime { get; set; }

    public DateTime? CancelTime { get; set; }

    #endregion

    #region Navigations

    public virtual Customer Customer { get; set; }

    public virtual ICollection<Product>? Products { get; set; }

    #endregion

}
