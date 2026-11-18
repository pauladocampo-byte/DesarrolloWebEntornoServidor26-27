using Microsoft.AspNetCore.Mvc;

namespace Actividad6.Controllers
{
    public class ProductoController : Controller
    {
        private const string SessionKeyProductos = "Productos";

        private List<string> GetProductosSesion()
        {
            var data = HttpContext.Session.GetString(SessionKeyProductos);
            if (string.IsNullOrEmpty(data))
                return new List<string>();
            return data.Split(';', StringSplitOptions.RemoveEmptyEntries).ToList();
        }

        private void GuardarProductosSesion(List<string> productos)
        {
            var data = string.Join(";", productos);
            HttpContext.Session.SetString(SessionKeyProductos, data);
        }

        // GET: /Producto/ListarProductos
        [HttpGet]
        public IActionResult ListarProductos()
        {
            return View();
        }

        // POST: /Producto/ListarProductos
        [HttpPost]
        public IActionResult ListarProductos(string nombreProducto)
        {
            if (!string.IsNullOrWhiteSpace(nombreProducto))
            {
                var productos = GetProductosSesion();
                productos.Add(nombreProducto.Trim());
                GuardarProductosSesion(productos);
            }

            return RedirectToAction(nameof(ListarProductos));
        }

        // GET: /Producto/MostrarProductos
        [HttpGet]
        public IActionResult MostrarProductos()
        {
            var productos = GetProductosSesion();
            return View(productos);
        }

        // GET: /Producto/EliminarProducto?index=0
        [HttpGet]
        public IActionResult EliminarProducto(int index)
        {
            var productos = GetProductosSesion();
            if (index >= 0 && index < productos.Count)
            {
                productos.RemoveAt(index);
                GuardarProductosSesion(productos);
            }
            return RedirectToAction(nameof(MostrarProductos));
        }

        // POST: /Producto/VaciarProductos
        [HttpPost]
        public IActionResult VaciarProductos()
        {
            HttpContext.Session.Remove(SessionKeyProductos);
            return RedirectToAction(nameof(MostrarProductos));
        }
    }
}
