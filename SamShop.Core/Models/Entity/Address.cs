using System;
using System.Collections.Generic;

namespace SamShop.Domain.Core.Models.Entity;

public partial class Address
{
    public int AddressId { get; set; }

    public string State { get; set; } = null!;

    public string City { get; set; } = null!;

    public string Street { get; set; } = null!;

    public string Alley { get; set; } = null!;

    public string ExtraPart { get; set; } = null!;

    public string PostCode { get; set; } = null!;

    public virtual Booth Address1 { get; set; } = null!;

    public virtual Seller Address2 { get; set; } = null!;

    public virtual Admin AddressNavigation { get; set; } = null!;

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    public virtual ICollection<Customer> CustomersNavigation { get; set; } = new List<Customer>();
}
