namespace SamShop.endpoint.Areas.Seller.Models
{
    public class AuctionOfferViewModel
    {
        public int OfferId { get; set; }

        public decimal OfferValue { get; set; }

        public int AuctionId { get; set; }
        public bool IsAccept { get; set; }
        public int CustomerId { get; set; }
        public DateTime OfferTime { get; set; }
        public string CustomerName { get; set; }
    }
}
