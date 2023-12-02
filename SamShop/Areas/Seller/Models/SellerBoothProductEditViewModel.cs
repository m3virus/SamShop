using Microsoft.AspNetCore.Mvc.Rendering;

namespace SamShop.endpoint.Areas.Seller.Models
{
    public class SellerBoothProductEditViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }
        public List<int> SelectedPictureIds { get; set; }
        public int SelectedCategoryId { get; set; }
        public int CurrentCategoryId { get; set; }
        public List<SellerPictureViewModel> ProductPictures { get; set; }
        public List<SelectListItem> AvailableCategories { get; set; }
        public List<IFormFile> NewPictures { get; set; }
    }
}
