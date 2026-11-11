using Microsoft.AspNetCore.Mvc;

namespace MontecasteloAuthDemo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();
        public IActionResult Privacy() => View();
    }
}
