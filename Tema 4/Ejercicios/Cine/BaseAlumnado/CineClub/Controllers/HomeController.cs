using Microsoft.AspNetCore.Mvc;

namespace CineClub.Controllers;

public class HomeController : Controller
{
    public IActionResult Index() => View();
}
