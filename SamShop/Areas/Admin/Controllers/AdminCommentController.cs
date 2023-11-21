using Microsoft.AspNetCore.Mvc;
using SamShop.Domain.Core.Interfaces.Repositories;
using SamShop.Domain.Core.Interfaces.Services;

namespace SamShop.endpoint.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminCommentController : Controller
    {
        
        private readonly ICommentServices _commentServices;

        public AdminCommentController(ICommentServices commentServices)
        {
            _commentServices = commentServices;
        }
        
        public async Task<IActionResult> Index()
        {
            var result = _commentServices.GetCommentsByIsAccepted();
            return View(result);

        }
        
        
        public async Task<IActionResult> Confirm(int commentId , CancellationToken cancellation)
        {
            await _commentServices.ConfirmComment(commentId, cancellation);
            return RedirectToAction("Index");
            //return View();
        }

        
        public async Task<IActionResult> Delete(int commentId, CancellationToken cancellation)
        {
            await _commentServices.DeleteComment(commentId, cancellation);
            return RedirectToAction("Index");
        }
    }
}
