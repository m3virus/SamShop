using SamShop.Domain.Core.Models.Entities;
using System.ComponentModel.DataAnnotations;
using SamShop.Domain.Core.Models.DtOs.AddressDtOs;
using SamShop.Domain.Core.Models.DtOs.BoothDtOs;
using SamShop.Domain.Core.Models.DtOs.MedalDtOs;

namespace SamShop.endpoint.Areas.Identity.Models
{
    public class SellerRegisterViewModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        [Required]
        public Address Address { get; set; }
        public IFormFile Image { get; set; }
        [Required]
        public BoothDtOs Booth { get; set; }
        [Required]
        public AddressDtOs BoothAddressDtOs { get; set; }
    }
}
