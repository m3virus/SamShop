using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SamShop.Domain.Core.Models.Entities;

public partial class Admin
{
    public int AdminId { get; set; }

    public int AddressId { get; set; }

    public int? PictureId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public decimal Wallet { get; set; }

    public string UserName { get; set; } = null!;

    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;

    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = null!;

    [DataType(DataType.PhoneNumber)]
    public string Phone { get; set; } = null!;

    public bool IsDeleted { get; set; }

    public virtual Address Address { get; set; } = null!;

    public virtual Picture? Picture { get; set; }
}
