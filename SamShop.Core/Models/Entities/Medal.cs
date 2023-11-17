using System;
using System.Collections.Generic;

namespace SamShop.Domain.Core.Models.Entities;

public partial class Medal
{
    #region Entities

    public int MedalId { get; set; }

    public string MedalType { get; set; }

    public bool IsDeleted { get; set; }

    public decimal WagePercentage { get; set; }

    public DateTime? DeleteTime { get; set; }

    public DateTime CreateTime { get; set; }

    #endregion

    #region Navigations

    public virtual Seller Seller { get; set; }

    #endregion

}
