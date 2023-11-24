using Microsoft.AspNetCore.Mvc;

namespace SamShop.endpoint.Areas.Seller.Controllers
{
    public class SellerPanelController : Controller
    {
        [Area("Seller")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
