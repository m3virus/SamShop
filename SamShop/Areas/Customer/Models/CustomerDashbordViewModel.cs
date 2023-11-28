using SamShop.Domain.Core.Models.DtOs.CustomerDtOs;

namespace SamShop.endpoint.Areas.Customer.Models
{
    public class CustomerDashbordViewModel
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal WalletAmount { get; set; }

        public CustomerDtOs? CustomerDtOs { get; set; }
        public List<AddressViewModel>? PrimaryAddresses { get; set; }
        public PictureViewModel? ProfilePicture { get; set; }
        public List<CartViewModel>? Carts { get; set; }
    }
}
