using SamShop.Domain.Core.Models.DtOs.AddressDtOs;

namespace SamShop.endpoint.Areas.Customer.Models
{
    public class CustomerProfileEditViewModel
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Wallet { get; set; }
        public List<AddressDtOs> Address { get; set; }
        public IFormFile picture { get; set; }

    }
}
