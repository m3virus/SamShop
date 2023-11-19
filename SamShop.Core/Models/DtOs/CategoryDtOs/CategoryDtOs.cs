using SamShop.Domain.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamShop.Domain.Core.Models.DtOs.CategoryDtOs
{
    public class CategoryDtOs
    {
        #region Entities

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public bool IsAccepted { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeleteTime { get; set; }

        public DateTime CreateTime { get; set; }

        #endregion

        #region Navigations

        public virtual ICollection<Product> Products { get; set; }

        #endregion
    }
}
