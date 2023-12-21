using SamShop.Domain.Core.Models.Entities;

namespace SamShop.endpoint.Models
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ? Price { get; set; }
        public int Amount { get; set; }
        public List<HomeCommentViewModel>? Comments { get; set; }
        public List<HomePictureViewModel>? pictures { get; set; }
        public CategoryViewModel? Category { get; set; }
        public BoothViewModel? Booth { get; set; }
    }
}
