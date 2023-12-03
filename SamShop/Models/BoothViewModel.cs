using SamShop.endpoint.Areas.Customer.Models;

namespace SamShop.endpoint.Models
{
    public class BoothViewModel
    {
        public int BoothId { get; set; }
        public string BoothName { get; set; }
        public List<ProductViewModel> Products { get; set; }
    }
}
