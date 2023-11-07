using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SamShop.Domain.Core.Interfaces.Repositories;
using SamShop.Infrastructure.DataAccess.Repositories;

namespace SamShop.endpoint.Areas.Admin.Controllers
{
    public class AdminPanelController : Controller
    {
        private readonly IAdminReository _adminReository;

        public AdminPanelController(IAdminReository adminReository)
        {
            _adminReository = adminReository;
        }
        [Area("Admin")]
        // GET: AdminPanelController
        public ActionResult Index()
        {
            
            return View(_adminReository.GetAllAdmin());
        }

        // GET: AdminPanelController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AdminPanelController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminPanelController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminPanelController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AdminPanelController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminPanelController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdminPanelController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
