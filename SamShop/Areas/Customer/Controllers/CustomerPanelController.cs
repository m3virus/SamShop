using Microsoft.AspNetCore.Mvc;

namespace SamShop.endpoint.Areas.Customer.Controllers
{
    public class CustomerPanelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
