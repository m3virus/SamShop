namespace SamShop.endpoint.Areas.Identity.Models
{
    public class SellerRegisterBoothVIewModel
    {
        public int BoothId { get; set; }
        public string BoothName { get; set;}
        public SellerRegisterAddressViewModel BoothAddress { get; set; }
    }
}
