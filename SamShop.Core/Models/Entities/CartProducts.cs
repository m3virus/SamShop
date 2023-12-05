using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamShop.Domain.Core.Models.Entities
{
    public class CartProducts
    {
        public int CartsCartId { get; set; }
        public int ProductsProductId { get; set; }

        public Cart CartsCart { get; set; }
        public Product ProductsProduct { get; set; }
    }
}
