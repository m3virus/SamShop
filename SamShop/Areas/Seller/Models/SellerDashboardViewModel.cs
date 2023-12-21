using SamShop.Domain.Core.Models.DtOs.AdminDtOs;
using SamShop.Domain.Core.Models.DtOs.SellerDtOs;
using SamShop.endpoint.Areas.Admin.Models;

namespace SamShop.endpoint.Areas.Seller.Models
{
    public class SellerDashboardViewModel
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal WalletAmount { get; set; }
        public string MedalType { get; set; }
        public SellerDtOs Seller { get; set; }
        public SellerAddressViewModel PrimaryAddresses { get; set; }
        public SellerPictureViewModel? ProfilePicture { get; set; }
        public SellerBoothViewModel Booth { get; set; }
    }
}
