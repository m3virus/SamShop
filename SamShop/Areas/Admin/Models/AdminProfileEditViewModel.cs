using SamShop.Domain.Core.Models.DtOs.AddressDtOs;

namespace SamShop.endpoint.Areas.Admin.Models
{
    public class AdminProfileEditViewModel
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public AdminAddressViewModel Address { get; set; }
        public IFormFile Picture { get; set; }
    }
}
