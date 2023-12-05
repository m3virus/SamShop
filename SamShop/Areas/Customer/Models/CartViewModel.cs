namespace SamShop.endpoint.Areas.Customer.Models
{
    public class CartViewModel
    {
        public int CartId { get; set; }
        public decimal Price { get; set; }
        public bool IsPayed { get; set; }
        public List<ProductViewModel>? Products { get; set; }

    }
}
