
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CatalogoTienda.Models;
using CatalogoTienda.Data;
using CatalogoTienda.Managers;

public class ProductosController : Controller
{
    private readonly ProductoManager _manager;

    public ProductosController(ProductoManager manager)
    {
        _manager = manager;
    }

    // GET: PRODUCTOS/Details/5
    public IActionResult Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var producto =  _manager.ObtenerPorId(id.Value);
        if (producto == null)
        {
            return NotFound();
        }

        return View(producto);
    }



    // GET: PRODUCTOS/Create
    public IActionResult Create()
    {
        return View(new Producto());
    }

    // POST: PRODUCTOS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Producto producto)
    {
        if (!ModelState.IsValid)
        {
            return View(producto);
        }
        _manager.Crear(producto);
        return RedirectToAction(nameof(Index));
    }

    // GET: PRODUCTOS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var producto = _manager.ObtenerPorId(id.Value);
        if (producto == null)
        {
            return NotFound();
        }
        return View(producto);
    }

    // POST: PRODUCTOS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, Producto producto)
    {
        if (id != producto.Id)
        {
            return NotFound();
        }

        if (!ModelState.IsValid)
        {
             return View(producto);
        }

        if (!_manager.Existe(id.Value))
        {
            return NotFound();
        }
        _manager.Actualizar(producto);
        return RedirectToAction(nameof(Index));
    }

    // GET: PRODUCTOS/Delete/5
    public IActionResult Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var producto = _manager.ObtenerPorId(id.Value);
        if (producto == null)
        {
            return NotFound();
        }

        return View(producto);
    }

    // POST: PRODUCTOS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        var eliminado = _manager.Eliminar(id);

        if (eliminado)
        {
            return RedirectToAction(nameof(Index));
        }
        else
        {
            return NotFound();
        }
       
    }

    // Actividad 3: lista completa.
    [HttpGet]
    public IActionResult Index()
    {
        return View(_manager.ListarTodos());
    }

    // Actividad 3: detalle con la ruta /Productos/Info/{id}.
    [HttpGet]
    public IActionResult Info(int id)
    {
        var producto = _manager.ObtenerPorId(id);
        return producto is null ? NotFound() : View(producto);
    }

    // Actividad 3: filtra por precio máximo y stock mínimo.
    [HttpGet]
    public IActionResult GetProductos(decimal precioMaximo, int stockMinimo)
    {
        ViewData["TituloLista"] = $"Hasta {precioMaximo:C} y con {stockMinimo} unidades o más";
        ViewData["PrecioMaximo"] = precioMaximo;
        ViewData["StockMinimo"] = stockMinimo;
        return View("Index", _manager.Filtrar(precioMaximo, stockMinimo));
    }
}
