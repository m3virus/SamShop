namespace SamShop.endpoint.Areas.Identity.Models
{
    public class SellerRegisterViewModel
    {
        public int MedalId { get; set; }
        public SellerRegisterAddressViewModel Address { get; set; }
        public IFormFile? Image { get; set; }
        public SellerRegisterBoothVIewModel Booth { get; set; }
        public SellerPictureRegisterViewModel? Picture { get; set; } 
    }
}
