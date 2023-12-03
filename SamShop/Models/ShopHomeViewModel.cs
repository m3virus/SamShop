using SamShop.Domain.Core.Models.Entities;

namespace SamShop.endpoint.Models
{
    public class ShopHomeViewModel
    {
        public List<CategoryViewModel> Categories { get; set; }
        public List<BoothViewModel> Booths { get; set; }
    }
}
