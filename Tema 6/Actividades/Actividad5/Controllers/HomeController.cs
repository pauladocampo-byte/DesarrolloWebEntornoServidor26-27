using Microsoft.AspNetCore.Mvc;

namespace Actividad5.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
