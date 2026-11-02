using CatalogoTienda.Data;
using CatalogoTienda.Models;

namespace CatalogoTienda.Managers
{
    public class ProductoManager
    {
        private readonly TiendaContext _context;
        public ProductoManager(TiendaContext context)
        {
            _context = context;
        }

        public List<Producto> ListarTodos()
        {
           return _context.Productos
                .OrderBy(producto=>producto.Nombre)
                .ToList();
        }
        public Producto? ObtenerPorId(int id)
        {
            return _context.Productos.FirstOrDefault(producto => producto.Id == id);
        }

        public List<Producto> Filtrar(decimal precioMaximo, int stockMinimo)
        {
           return _context.Productos
                .Where(producto => producto.Precio <= precioMaximo && producto.Stock >= stockMinimo)
                .OrderBy(producto => producto.Nombre)
                .ToList();
        }

        public void Crear(Producto producto)
        {
            _context.Productos.Add(producto);
            _context.SaveChanges();
        }

        public bool Existe(int id)
        {
            //return _context.Productos.Where(producto => producto.Id == id).ToList().Count() > 0 ;
            return  _context.Productos.Any(producto => producto.Id == id);
        }

        public void Actualizar(Producto producto)
        {
            _context.Productos.Update(producto);
            _context.SaveChanges();
        }

        public bool Eliminar(int id)
        {
           // var producto = _context.Productos.FirstOrDefault(producto => producto.Id == id);
            var producto = ObtenerPorId(id);
            if (producto == null)
                return false;

            _context.Productos.Remove(producto);
            _context.SaveChanges();
            return true;
        }
    }
}
