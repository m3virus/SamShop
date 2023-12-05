namespace SamShop.endpoint.Areas.Seller.Models
{
    public class AuctionViewModel
    {
        public int AuctionId { get; set; }
        public bool IsActive { get; set; }
        public string AuctionName { get; set; }
        public decimal LowestOffer { get; set; }
        public string BoothName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string ProductName { get; set; }
        public List<AuctionOfferViewModel> AuctionOffers { get; set; }
        public List<SellerPictureViewModel> ProductPictures { get; set; }
    }
}
