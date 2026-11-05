using Microsoft.AspNetCore.Mvc;

namespace HuertoUrbano.Controllers;

public class HomeController : Controller
{
    public IActionResult Index() => View();
}
