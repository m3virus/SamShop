using System.ComponentModel.DataAnnotations;
using SamShop.Domain.Core.Models.Entities;

namespace SamShop.endpoint.Areas.Identity.Models
{
    public class CustomerRegisterViewModel
    {
        
        
        public string FirstName { get; set; }
       
        public string UserName { get; set; }
        
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
        public Address Address { get; set; }
        
        [DataType(DataType.ImageUrl)]
        [Display(Name = "Image url")]
        public IFormFile Image { get; set; }

    }
}
