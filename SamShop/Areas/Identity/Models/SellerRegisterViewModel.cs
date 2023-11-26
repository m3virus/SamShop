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
        [Required(ErrorMessage = "email is required")]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "password is required")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "phone number is required")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
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
