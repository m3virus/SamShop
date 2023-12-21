using SamShop.Domain.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamShop.Domain.Core.Models.DtOs.CustomerDtOs
{
    public class CustomerDtOs
    {
        #region Entities

        public int CustomerId { get; set; }

        public decimal Wallet { get; set; }

        public int? PictureId { get; set; }

        public int AppUserId { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeleteTime { get; set; }

        public DateTime CreateTime { get; set; }

        #endregion

        #region Navigatons

        public virtual ICollection<Address> Addresses { get; set; }

        public virtual ICollection<AuctionOffer> AuctionOffers { get; set; }

        public virtual ICollection<Cart> Carts { get; set; }

        public virtual ICollection<Comment> Comment { get; set; }

        public virtual Picture? Picture { get; set; }

        public virtual AppUser? AppUser { get; set; }


        #endregion
    }
}
