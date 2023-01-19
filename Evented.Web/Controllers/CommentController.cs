using Microsoft.AspNetCore.Mvc;

namespace Evented.Web.Controllers
{
    public class CommentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
