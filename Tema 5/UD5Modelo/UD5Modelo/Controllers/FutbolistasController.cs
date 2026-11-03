using Microsoft.AspNetCore.Mvc;
using UD5Modelo.Models;
using UD5Modelo.Models.Manager;

namespace UD5Modelo.Controllers
{
    public class FutbolistasController : Controller
    {
        private readonly IFutbolistaManager _manager;

        public FutbolistasController(IFutbolistaManager manager)
        {
            _manager = manager;
        }

        // LISTADO
        public IActionResult Index()
        {
            var lista = _manager.GetAll();
            return View(lista);
        }

        // DETALLES (opcional si tienes la vista)
        [HttpGet]
        public IActionResult Detalles(int id)
        {
            var f = _manager.GetById(id);
            if (f is null) return NotFound();
            return View(f);
        }

        // CREAR
        [HttpGet]
        public IActionResult Crear()
        {
            ViewBag.Equipos = _manager.GetEquipos(); // para el <select> de EquipoId si lo usas
            return View(new Futbolista());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(Futbolista m)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Equipos = _manager.GetEquipos();
                return View(m);
            }

            _manager.Create(m);
            return RedirectToAction(nameof(Index));
        }

        // EDITAR
        [HttpGet]
        public IActionResult Editar(int id)
        {
            var f = _manager.GetById(id);
            if (f is null) return NotFound();

            ViewBag.Equipos = _manager.GetEquipos();
            return View(f);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Futbolista m)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Equipos = _manager.GetEquipos();
                return View(m);
            }

            _manager.Update(m);
            return RedirectToAction(nameof(Index));
        }

        // ELIMINAR (GET confirmación + POST)
        [HttpGet]
        public IActionResult Eliminar(int id)
        {
            var f = _manager.GetById(id);
            if (f is null) return NotFound();
            return View(f);
        }

        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public IActionResult EliminarConfirmado(int id)
        {
            _manager.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        // Actividad 4: Validación "remota" para comprobar dorsal libre en un equipo
        [HttpGet]
        public JsonResult IsDorsalDisponible(int? dorsal, int? equipoId, int id)
        {
            var libre = _manager.IsDorsalDisponible(dorsal, equipoId, id);
            return Json(libre);
        }
    }
}
