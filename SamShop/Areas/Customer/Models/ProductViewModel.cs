﻿using SamShop.endpoint.Areas.Seller.Models;

namespace SamShop.endpoint.Areas.Customer.Models
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }
        public List<PictureViewModel> ProductPictures { get; set; }
        public CustomerCategoryViewModel ProductCategory { get; set; }
        public CustomerBoothViewModel ProductBooth { get; set; }
    }
}
