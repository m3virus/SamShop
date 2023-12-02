namespace SamShop.endpoint.Areas.Seller.Models
{
    public class SellerBoothViewModel
    {
        public int BoothId { get; set; }    
        public string BoothName { get; set; }
        public SellerAddressViewModel BoothAddress { get; set; }
        public List<SellerBoothProductViewModel> BoothProducts { get; set; }
    }
}
