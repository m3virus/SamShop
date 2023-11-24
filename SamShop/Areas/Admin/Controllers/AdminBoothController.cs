using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SamShop.Domain.Core.Interfaces.AppServices;
using SamShop.Domain.Core.Models.DtOs.BoothDtOs;
using SamShop.Domain.Service;

namespace SamShop.endpoint.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminBoothController : Controller
    {
        protected readonly IBoothAppServices _boothAppServices;

        public AdminBoothController(IBoothAppServices boothAppServices)
        {
            _boothAppServices = boothAppServices;
        }

        public IActionResult Index()
        {
            return View(_boothAppServices.GetAllBooth().Where(x => x.IsDeleted !=true));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int BoothId , CancellationToken cancellation)
        {
            var booth = await _boothAppServices.GetBoothById(BoothId, cancellation);
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
            await _boothAppServices.UpdateBooth(boothDtOs, cancellation);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int boothId, CancellationToken cancellation)
        {
            await _boothAppServices.DeleteBooth(boothId, cancellation);
            return RedirectToAction("Index");
        }
    }
}
