using Microsoft.AspNetCore.Mvc;
using SamShop.Domain.Core.Interfaces.AppServices.BoothAppServices;
using SamShop.Domain.Core.Interfaces.Services;
using SamShop.Domain.Core.Models.DtOs.BoothDtOs;
using SamShop.Domain.Service;

namespace SamShop.endpoint.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminBoothController : Controller
    {
        protected readonly IBoothServices _boothServices;

        public AdminBoothController(IBoothServices boothServices)
        {
            _boothServices = boothServices;
        }

        public IActionResult Index()
        {
            return View(_boothServices.GetAllBooth().Where(x => x.IsDeleted !=true));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int BoothId , CancellationToken cancellation)
        {
            var booth = await _boothServices.GetBoothById(BoothId, cancellation);
            if (booth != null)
            {
                return View(booth);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(BoothDtOs boothDtOs, CancellationToken cancellation)
        {
            await _boothServices.UpdateBooth(boothDtOs, cancellation);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int boothId, CancellationToken cancellation)
        {
            await _boothServices.DeleteBooth(boothId, cancellation);
            return RedirectToAction("Index");
        }
    }
}
