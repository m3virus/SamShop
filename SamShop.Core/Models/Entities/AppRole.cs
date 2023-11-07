using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace SamShop.Domain.Core.Models.Entities
{
    public class AppRole : IdentityRole
    {
        public string description { get; set; }
    }
}
