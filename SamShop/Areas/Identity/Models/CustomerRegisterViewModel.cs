using System.ComponentModel.DataAnnotations;
using SamShop.Domain.Core.Models.Entities;

namespace SamShop.endpoint.Areas.Identity.Models
{
    public class CustomerRegisterViewModel
    {
        public int CustomerId { get; set; }
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

    }
}
