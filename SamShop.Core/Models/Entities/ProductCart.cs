using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamShop.Domain.Core.Models.Entities
{
    public class ProductCart
    {
        #region Entities

        public int Id { get; set; }

        public int ProductId { get; set; }
        public int CartId { get; set; }

        #endregion

        #region Navigation

        public Cart Cart { get; set; }
        public Product Product { get; set; }

        #endregion

    }
}
