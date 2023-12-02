using Microsoft.AspNetCore.Mvc.Rendering;

namespace SamShop.endpoint.Areas.Seller.Models
{
    public class SellerBoothProductAdderViewModel
    {
        public int BoothId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }
        public int SelectedCategoryId { get; set; }
        public List<SelectListItem>? AvailableCategories { get; set; }
        public List<IFormFile>? NewPictures { get; set; }
    }
}
