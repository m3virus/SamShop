using Microsoft.AspNetCore.Mvc;
using SamShop.Domain.Core.Interfaces.AppServices;
using SamShop.Domain.Core.Interfaces.Services;
using SamShop.Domain.Service;

namespace SamShop.endpoint.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminWageController : Controller
    {
        
        protected readonly IWageAppServices _wageAppServices;

        public AdminWageController(IWageAppServices wageAppServices)
        {
            _wageAppServices = wageAppServices;
        }

        public IActionResult Index()
        {
            return View(_wageAppServices.GetAllWage().OrderBy(x => x.PayTime));
        }
    }
}
