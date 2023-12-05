namespace SamShop.endpoint.Areas.Seller.Models
{
    public class AuctionAdderViewModel
    {
        public string Title { get; set; }
        public decimal TheLowestPrice { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public SellerBoothProductAdderViewModel Product { get; set; }
    }
}
