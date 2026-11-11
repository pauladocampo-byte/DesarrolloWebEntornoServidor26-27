using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MontecasteloAuthDemo.Models;

namespace MontecasteloAuthDemo.Controllers
{
    [Authorize(Roles = Roles.Admin)]
    public class AdminController : Controller
    {
        public IActionResult Index() => View();
    }
}
