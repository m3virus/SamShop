using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace SamShop.Domain.Core.Models.Entities
{
    public class AppUser :IdentityUser
    {
        public bool IsDeleted { get; set; }
        public DateTime RegisterTime { get; set; }


        public virtual Admin? Admin { get; set; }
        public virtual Seller? Seller { get; set; }
        public virtual Customer? Customer { get; set; }
    }
}
