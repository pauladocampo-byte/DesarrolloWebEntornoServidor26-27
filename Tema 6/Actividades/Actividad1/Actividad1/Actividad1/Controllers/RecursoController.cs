using Microsoft.AspNetCore.Mvc;

namespace Actividad1.Controllers
{
    public class RecursoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Listar()
        {
            return Content("Muestro una lista de recursos");
        }
        public IActionResult Detalles(int id)
        {
            return Content("Muestro los detalles de un recurso con ID: " + id);
        }
        public IActionResult Descargar()
        {
            return Content("Descarga el recurso");
        }
    }
}
