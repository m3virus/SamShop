using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SamShop.Domain.Core.Interfaces.AppServices;
using SamShop.Domain.Core.Models.DtOs.BoothDtOs;
using SamShop.Domain.Service;
using SamShop.endpoint.Areas.Admin.Models;

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
            var mainBooth = new AdminBoothViewModel
            {
                BoothId = booth.BoothId,
                BoothName = booth.BoothName,
                BoothCreateAt = booth.CreateTime
            };
            if (booth != null)
            {
                return View(mainBooth);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AdminBoothViewModel boothDtOs, CancellationToken cancellation)
        {
            var editedBooth = await _boothAppServices.GetBoothById(boothDtOs.BoothId, cancellation);
            if (editedBooth != null)
            {
                editedBooth.BoothName = boothDtOs.BoothName;
                editedBooth.CreateTime = boothDtOs.BoothCreateAt;

                await _boothAppServices.UpdateBooth(editedBooth, cancellation);
                return RedirectToAction("Index");
            }
            else
            {
                return NotFound();
            }

            
        }

        public async Task<IActionResult> Delete(int boothId, CancellationToken cancellation)
        {
            await _boothAppServices.DeleteBooth(boothId, cancellation);
            return RedirectToAction("Index");
        }
    }
}
