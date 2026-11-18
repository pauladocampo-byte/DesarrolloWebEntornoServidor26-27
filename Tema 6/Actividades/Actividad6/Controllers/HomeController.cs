using Microsoft.AspNetCore.Mvc;

namespace Actividad6.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
