using Actividad4.Models;
using Microsoft.AspNetCore.Mvc;

namespace Actividad4.Controllers
{
    public class UsuarioController : Controller
    {
        [HttpGet]
        public IActionResult RegistrarUsuario()
        {
            var modelo = new Registro
            {
                Direccion = new Direccion()
            };

            return View(modelo);
        }

        [HttpPost]
        public IActionResult RegistrarUsuario(Registro registro)
        {
            if (!ModelState.IsValid)
            {
                return View(registro);
            }

            // Aquí iría la lógica de guardar el usuario en BBDD

            var resumen =
                $"Usuario: {registro.Nombre} {registro.Apellido}, " +
                $"Email: {registro.CorreoElectronico}, " +
                $"Ciudad: {registro.Direccion.Ciudad}";

            return Content(resumen);
        }
    }
}
