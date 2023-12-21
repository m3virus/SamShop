using System.ComponentModel.DataAnnotations;
using SamShop.Domain.Core.Models.Entities;

namespace SamShop.endpoint.Areas.Identity.Models
{
    public class CustomerRegisterViewModel
    {

        [Required(ErrorMessage = "please enter your name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "please enter your the username you want")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "please enter your name")]
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
        [Required(ErrorMessage = "we should have your address")]
        public Address Address { get; set; }
        public IFormFile? Image { get; set; }

    }
}
