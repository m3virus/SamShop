using SamShop.Domain.Core.Models.DtOs.AdminDtOs;
using SamShop.endpoint.Areas.Customer.Models;

namespace SamShop.endpoint.Areas.Admin.Models
{
    public class AdminDashboardViewModel
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal WalletAmount { get; set; }

        public AdminDtOs? AdminDtOs { get; set; }
        public AdminAddressViewModel PrimaryAddresses { get; set; }
        public AdminPictureViewModel? ProfilePicture { get; set; }
    }
}
