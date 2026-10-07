using Ejercicio2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ejercicio2.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        var modelo = new PaisesViewModel
        {
            Paises = ["Argentina", "Brasil", "Canadá", "Dinamarca", "Egipto", "Francia"]
        };

        return View(modelo);
    }
}
