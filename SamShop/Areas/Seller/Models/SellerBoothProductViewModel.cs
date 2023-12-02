namespace SamShop.endpoint.Areas.Seller.Models
{
    public class SellerBoothProductViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }
        public List<SellerPictureViewModel> ProductPictures { get; set; }
        public SellerBoothProductCategoryViewModel ProductCategory { get; set; }
    }
}
