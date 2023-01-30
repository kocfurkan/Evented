using Microsoft.AspNetCore.Mvc;

namespace Evented.Web.Controllers
{
    public class HireController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
