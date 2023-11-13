using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SamShop.Domain.Core.Models.Entities;

public partial class Admin
{
    public int AdminId { get; set; }

    public int AddressId { get; set; }

    public int? PictureId { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? DeleteTime { get; set; }

    public DateTime CreateTime { get; set; }

    public int AppUserId { get; set; }

    public decimal Wallet { get; set; }

    public virtual Address Address { get; set; } 

    public virtual Picture? Picture { get; set; }

    public virtual AppUser Appuser { get; set; } 

    public virtual ICollection<Wage> Wages { get; set; } 



}
