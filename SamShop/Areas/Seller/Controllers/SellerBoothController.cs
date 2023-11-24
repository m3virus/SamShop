using Microsoft.AspNetCore.Mvc;

namespace SamShop.endpoint.Areas.Seller.Controllers
{
    public class SellerBoothController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
