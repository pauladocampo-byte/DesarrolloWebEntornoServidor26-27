using Microsoft.AspNetCore.Mvc;

namespace Actividad1.Controllers
{
	public class ProductoController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
        //https://localhost:7047/Producto/Listar
        public IActionResult Listar()
		{
			return Content("Muestro una lista de productos");
		}
        //https://localhost:7047/Producto/Detalles/1
        // [FromQuery]  int id) https://localhost:7047/Producto/Detalles?id=5
        public IActionResult Detalles([FromQuery]  int id)
		{
			return Content("Muestro los detalles del producto con ID: " + id);
		}
        //https://localhost:7047/Producto/Buscar?nombre=mando
        public IActionResult Buscar(string nombre)
		{
			return Content("Busco productos que tengan este nombre: " + nombre);
		}
	}
}
