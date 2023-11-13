using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace SamShop.Domain.Core.Models.Entities
{
    public class AppRole:IdentityRole<int>
    {
        public string Discription { get; set; }
    }
}
