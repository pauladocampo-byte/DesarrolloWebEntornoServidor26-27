using Microsoft.AspNetCore.Mvc;

namespace Actividad5.Models
{
    // Solo queremos que se bindeen Nombre y Precio para cada producto.
    [Bind("Nombre,Precio")]
    public class ProductoBind
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public string? Categoria { get; set; }
        public bool Descatalogado { get; set; }
    }

    public class PedidoBind
    {
        public string Cliente { get; set; } = string.Empty;
        public List<ProductoBind> Productos { get; set; } = new();
    }
}
