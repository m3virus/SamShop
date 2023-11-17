using SamShop.Domain.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamShop.Domain.Core.Models.DtOs
{
    public class PictureDtOs
    {
        #region Entities

        public int PictureId { get; set; }

        public string Url { get; set; }

        public int? ProductId { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime? DeleteTime { get; set; }

        #endregion

        #region Navigations

        public virtual Admin? Admin { get; set; }

        public virtual Customer? Customer { get; set; }

        public virtual Product? Product { get; set; }

        public virtual Seller? Seller { get; set; }

        #endregion
    }
}
