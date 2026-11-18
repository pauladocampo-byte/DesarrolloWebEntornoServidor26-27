using Microsoft.AspNetCore.Mvc;

namespace Actividad2.Controllers
{
	public class ProductoController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
		[Route("Listar/{categoria?}/{marca?}")]
		public IActionResult Listado(string categoria, string marca)
		{
			return Content("Muestro una lista de productos");
		}
		[Route("producto/detalles/{id:int:length(4)}-{slug:alpha}")]
		public IActionResult Detalles(int id, string slug)
		{
			return Content($"Muestro los detalles del producto con ID: {id} y slug: {slug}");
		}
		[Route("Producto/Buscar/{q}")]
		public IActionResult Buscar(string q)
		{
			return Content("Busco productos que tengan este parametro: " + q);
		}
	}
}
