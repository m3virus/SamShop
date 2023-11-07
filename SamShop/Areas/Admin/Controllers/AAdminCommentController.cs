using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SamShop.Domain.Core.Interfaces.Services;

namespace SamShop.endpoint.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AAdminCommentController : Controller
    {
        private readonly ICommentServices _commentServices;

        public AAdminCommentController(ICommentServices commentServices)
        {
            _commentServices = commentServices;
        }

        // GET: AAdminCommentController
        public ActionResult Index()
        {
            return View(_commentServices.GetCommentsByIsAccepted());
        }

        // GET: AAdminCommentController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AAdminCommentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AAdminCommentController/Create
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

        // GET: AAdminCommentController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AAdminCommentController/Edit/5
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

        // GET: AAdminCommentController/Delete/5
        public async Task<ActionResult> Delete(int commentId , CancellationToken cancellation)
        {
            await _commentServices.DeleteComment(commentId, cancellation);
            return RedirectToAction("Index");
            
        }

        // POST: AAdminCommentController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
