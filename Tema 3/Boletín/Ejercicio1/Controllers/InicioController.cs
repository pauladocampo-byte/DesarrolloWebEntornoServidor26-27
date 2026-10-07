using Ejercicio1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ejercicio1.Controllers;

public class InicioController : Controller
{
    [HttpGet]
    public IActionResult Bienvenida(string? NombreDeUsuario)
    {
        var modelo = new BienvenidaViewModel(NombreDeUsuario?.Trim());
        return View(modelo);
    }
}
