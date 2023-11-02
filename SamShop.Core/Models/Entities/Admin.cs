using System;
using System.Collections.Generic;

namespace SamShop.Domain.Core.Models.Entities;

public partial class Admin
{
    public int AdminId { get; set; }

    public string UserName { get; set; } = null!;

    public int AddressId { get; set; }

    public int? PictureId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public decimal Wallet { get; set; }

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public bool IsDeleted { get; set; }

    public virtual Address Address { get; set; } = null!;

    public virtual Picture? Picture { get; set; }
}
