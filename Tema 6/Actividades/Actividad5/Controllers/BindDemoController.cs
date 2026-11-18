using Actividad5.Models;
using Microsoft.AspNetCore.Mvc;

namespace Actividad5.Controllers
{
    public class BindDemoController : Controller
    {
        // PUNTO 1 + 3: incluir solo algunas propiedades
        [HttpGet]
        public IActionResult EditarUsuario()
        {
            var modelo = new Usuario
            {
                Id = 1,
                Nombre = "Ana",
                Apellido = "García",
                CorreoElectronico = "ana@ejemplo.com",
                EsAdmin = true
            };

            return View(modelo);
        }

        [HttpPost]
        public IActionResult EditarUsuario([Bind("Nombre,CorreoElectronico")] Usuario usuario)
        {
            var resumen = $"Nombre = {usuario.Nombre}, " +
                          $"Correo = {usuario.CorreoElectronico}, " +
                          $"Apellido = {usuario.Apellido}, " +
                          $"EsAdmin = {usuario.EsAdmin}";

            return Content(resumen);
        }

        // PUNTO 2: lista de objetos con Bind en el tipo ProductoBind
        [HttpGet]
        public IActionResult EditarPedido()
        {
            var modelo = new PedidoBind
            {
                Cliente = "Cliente demo",
                Productos = new List<ProductoBind>
                {
                    new ProductoBind { Id = 1, Nombre = "Ratón",   Precio = 10, Categoria = "Periféricos", Descatalogado = false },
                    new ProductoBind { Id = 2, Nombre = "Teclado", Precio = 20, Categoria = "Periféricos", Descatalogado = false }
                }
            };

            return View(modelo);
        }

        [HttpPost]
        public IActionResult EditarPedido(PedidoBind pedido)
        {
            var texto = $"Cliente: {pedido.Cliente}\n";
            int i = 1;
            foreach (var p in pedido.Productos)
            {
                texto += $"Producto {i}: Nombre={p.Nombre}, Precio={p.Precio}, " +
                         $"Categoria={p.Categoria}, Descatalogado={p.Descatalogado}\n";
                i++;
            }

            return Content(texto);
        }

        // PUNTO 4: usar Bind Exclude
        [HttpGet]
        public IActionResult EditarUsuarioExclude()
        {
            var modelo = new Usuario
            {
                Id = 2,
                Nombre = "Pepe",
                Apellido = "López",
                CorreoElectronico = "pepe@ejemplo.com",
                EsAdmin = true
            };

            return View(modelo);
        }

        //[HttpPost]
        //public IActionResult EditarUsuarioExclude([Bind(Exclude = "EsAdmin")] Usuario usuario)
        //{
        //    var texto = $"Nombre={usuario.Nombre}, Apellido={usuario.Apellido}, " +
        //                $"Correo={usuario.CorreoElectronico}, EsAdmin={usuario.EsAdmin}";

        //    return Content(texto);
        //}

        [HttpPost]
        public IActionResult EditarUsuarioExclude([Bind("Nombre,Apellido,CorreoElectronico")] Usuario usuario)
        {
            var texto = $"Nombre={usuario.Nombre}, Apellido={usuario.Apellido}, " +
                        $"Correo={usuario.CorreoElectronico}, EsAdmin={usuario.EsAdmin}";

            return Content(texto);
        }
    }
}
