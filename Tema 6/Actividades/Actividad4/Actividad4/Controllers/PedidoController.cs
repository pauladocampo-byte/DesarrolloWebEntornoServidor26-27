using Actividad4.Models;
using Microsoft.AspNetCore.Mvc;

namespace Actividad4.Controllers
{
    public class PedidoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CrearPedido()
        {
            var modelo = new Pedido
            {
                // Dejamos 3 productos vacíos para que salgan en el formulario
                Productos = new List<Producto>
            {
                new Producto(),
                new Producto(),
                new Producto()
            }
            };

            return View(modelo);
        }


        [HttpPost]
        public IActionResult CrearPedido(Pedido pedido)
        {
            if (!ModelState.IsValid)
            {
                return View(pedido);
            }

            // Aquí iría la lógica de guardar el pedido en BBDD
            // _repoPedidos.Insertar(pedido);

            // Para comprobar el binding:
            var resumen = $"Pedido de {pedido.Cliente} en {pedido.Ciudad}. " +
                          $"Productos: {pedido.Productos.Count}";

            return Content(resumen);
        }

    }
}
