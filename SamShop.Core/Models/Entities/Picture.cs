using System;
using System.Collections.Generic;

namespace SamShop.Domain.Core.Models.Entities;

public partial class Picture
{
    public int PictureId { get; set; }

    public string Url { get; set; } = null!;

    public int? ProductId { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<Admin> Admins { get; set; } = new List<Admin>();

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    public virtual Product? Product { get; set; }

    public virtual ICollection<Seller> Sellers { get; set; } = new List<Seller>();
}
