using SamShop.endpoint.Areas.Customer.Models;

namespace SamShop.endpoint.Models
{
    public class CategoryViewModel
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<ProductViewModel> Products { get; set; }
    }
}
