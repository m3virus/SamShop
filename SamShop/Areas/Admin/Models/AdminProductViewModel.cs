using Microsoft.AspNetCore.Mvc.Rendering;
using SamShop.endpoint.Areas.Seller.Models;

namespace SamShop.endpoint.Areas.Admin.Models
{
    public class AdminProductViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }
        public List<int>? SelectedPictureIds { get; set; }
        public int SelectedCategoryId { get; set; }
        public int CurrentCategoryId { get; set; }
        public List<AdminPictureViewModel>? ProductPictures { get; set; }
        public List<SelectListItem> AvailableCategories { get; set; }
        public List<IFormFile>? NewPictures { get; set; }
    }
}
