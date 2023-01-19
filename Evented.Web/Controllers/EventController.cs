using Microsoft.AspNetCore.Mvc;

namespace Evented.Web.Controllers
{
    public class EventController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
