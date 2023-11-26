using SamShop.Domain.Core.Models.Entities;

namespace SamShop.endpoint.Models
{
    public class BoothViewModel
    {
        public string BoothName { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
