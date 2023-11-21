using Microsoft.AspNetCore.Mvc;
using SamShop.Domain.Core.Interfaces.Services;
using SamShop.Domain.Service;

namespace SamShop.endpoint.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminWageController : Controller
    {
        
        protected readonly IWageServices _wageServices;

        public AdminWageController(IWageServices wageServices)
        {
            _wageServices = wageServices;
        }

        public IActionResult Index()
        {
            return View(_wageServices.GetAllWage().OrderBy(x => x.PayTime));
        }
    }
}
