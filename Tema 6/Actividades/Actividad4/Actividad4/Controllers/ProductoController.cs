using Actividad4.Models;
using Microsoft.AspNetCore.Mvc;

namespace Actividad4.Controllers
{
    public class ProductoController : Controller
    {
        // Catálogo simulado en memoria
        private static readonly List<Producto> _catalogo = new()
        {
            new Producto { Nombre = "Ratón inalámbrico", Precio = 15, Descripcion = "Ratón óptico 2.4GHz" },
            new Producto { Nombre = "Teclado mecánico", Precio = 40, Descripcion = "Teclado con switches azules" },
            new Producto { Nombre = "Monitor 24\"", Precio = 120, Descripcion = "Monitor Full HD" },
            new Producto { Nombre = "Auriculares", Precio = 30, Descripcion = "Auriculares con micrófono" },
        };

        // GET /Producto/BuscarProductos
        [HttpGet]
        public IActionResult BuscarProductos()
        {
            // Modelo vacío para mostrar el formulario
            var modelo = new Busqueda();
            return View(modelo);
        }

        // POST /Producto/BuscarProductos
        [HttpPost]
        public IActionResult BuscarProductos(Busqueda criterios)
        {
            // Partimos de todo el catálogo
            IEnumerable<Producto> query = _catalogo;

            if (!string.IsNullOrWhiteSpace(criterios.Nombre))
            {
                query = query.Where(p =>
                    p.Nombre.Contains(criterios.Nombre, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrWhiteSpace(criterios.Descripcion))
            {
                query = query.Where(p =>
                    (p.Descripcion ?? string.Empty)
                        .Contains(criterios.Descripcion, StringComparison.OrdinalIgnoreCase));
            }

            if (criterios.PrecioMinimo.HasValue)
            {
                query = query.Where(p => p.Precio >= criterios.PrecioMinimo.Value);
            }

            if (criterios.PrecioMaximo.HasValue)
            {
                query = query.Where(p => p.Precio <= criterios.PrecioMaximo.Value);
            }

            var resultados = query.ToList();

            // Mandamos el modelo de búsqueda + resultados a la vista
            ViewBag.Resultados = resultados;

            return View(criterios); // reutilizamos la misma vista
        }
    }
}
