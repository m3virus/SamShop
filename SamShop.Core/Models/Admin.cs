﻿using System;
using System.Collections.Generic;

namespace SamShop.Domain.Core.Models;

public partial class Admin
{
    public int AdminId { get; set; }

    public string UserName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public bool IsDeleted { get; set; }

    public virtual Address? Address { get; set; }

    public virtual Wallet Admin1 { get; set; } = null!;

    public virtual Picture AdminNavigation { get; set; } = null!;
}