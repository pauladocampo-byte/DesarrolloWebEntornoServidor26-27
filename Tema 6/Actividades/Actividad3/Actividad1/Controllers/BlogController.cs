using Actividad1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Actividad1.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Listar()
        {
            return Content("Muestro una lista de contenidos del blog");
        }
        public IActionResult Detalles(int id)
        {
            return Content("Muestro los detalles de un articulo del blog con ID: " + id);
        }

        public IActionResult Crear(Blog blog)
        {
            return Content("Crea una nueva publicacion");
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            return Content("Obtiene de BBDD el contenido del blog y lo muestra en la vista");
        }

        [HttpPost]
        public IActionResult Editar(Blog blog)
        {
            return Content("Obtiene el contenido modificado, crea el blog y lo actualiza en la BBDD");
        }

        public IActionResult Eliminar(int id)
        {
            return Content("Obtiene una publicacion de blog y la elimina");
        }

    }
}
