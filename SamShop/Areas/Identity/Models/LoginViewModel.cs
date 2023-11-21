using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SamShop.endpoint.Areas.Identity.Models
{
    public class LoginViewModel
    {
        [Required (ErrorMessage = "email is required")]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required (ErrorMessage = "password is required")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        
        public bool RememberMe { get; set; }


    }
}
