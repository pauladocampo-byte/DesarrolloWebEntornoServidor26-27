using Actividad1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Actividad1.Controllers
{
    public class TiendaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Listar()
        {
            return Content("Muestro una lista de productos en la tienda");
        }
        public IActionResult Detalles(int id)
        {
            return Content("Muestro los detalles de producto con ID: " + id);
        }
        public IActionResult AgregarAlCarrito(Producto producto)
        {
            return Content("Meter en la variable de sesion el producto");
        }
        public IActionResult RealizarPedido()
        {
            return Content("Realiza un pedido");
        }
    }
}
