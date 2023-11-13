using System;
using System.Collections.Generic;

namespace SamShop.Domain.Core.Models.Entities;

public partial class Address
{
    public int AddressId { get; set; }

    public string State { get; set; } 

    public string City { get; set; } 

    public string Street { get; set; } 

    public string Alley { get; set; }

    public string ExtraPart { get; set; }

    public string PostCode { get; set; } 

    public bool IsDeleted { get; set; } 

    public virtual Admin? Admin { get; set; }
    public virtual ICollection<AddressCustomer>? AddressCustomers { get; set; }
    public virtual Seller? Seller { get; set; } 
    public virtual Booth? Booth { get; set; } 




}
