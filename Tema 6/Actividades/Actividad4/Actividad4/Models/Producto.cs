namespace Actividad4.Models
{
    public class Producto
    {
        public string Nombre { get; set; }
        public float Precio { get; set; }

        public string? Descripcion { get; set; }   //para la busqueda
    }
}
