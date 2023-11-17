using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamShop.Domain.Core.Models.Entities
{
    public class AddressCustomer
    {
        #region Entities

        public int Id { get; set; }

        public int AddressId { get; set; }
        public int CustomerId { get; set; }

        #endregion

        #region Navigation

        public Address Address { get; set; }
        public Customer Customer { get; set; }

        #endregion

    }
}
