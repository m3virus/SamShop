using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SamShop.Domain.Core.Interfaces.AppServices;
using SamShop.Domain.Core.Interfaces.Repositories;

namespace SamShop.endpoint.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminCommentController : Controller
    {
        
        private readonly ICommentAppServices _commentAppServices;

        public AdminCommentController(ICommentAppServices commentAppServices)
        {
            _commentAppServices = commentAppServices;
        }
        
        public async Task<IActionResult> Index()
        {
            var result = _commentAppServices.GetCommentsByIsAccepted();
            return View(result);

        }
        
        
        public async Task<IActionResult> Confirm(int commentId , CancellationToken cancellation)
        {
            await _commentAppServices.ConfirmComment(commentId, cancellation);
            return RedirectToAction("Index");
            //return View();
        }

        
        public async Task<IActionResult> Delete(int commentId, CancellationToken cancellation)
        {
            await _commentAppServices.DeleteComment(commentId, cancellation);
            return RedirectToAction("Index");
        }
    }
}
