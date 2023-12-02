using SamShop.endpoint.Areas.Admin.Models;

namespace SamShop.endpoint.Areas.Seller.Models
{
    public class SellerProfileEditViewModel
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public SellerAddressViewModel Address { get; set; }
        public IFormFile Picture { get; set; }
    }
}
