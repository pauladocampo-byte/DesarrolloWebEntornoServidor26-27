namespace Actividad4.Models
{
    public class Pedido
    {
        public string Cliente { get; set; }
        public string Direccion { get; set; }
        public string Ciudad { get; set; }

        public List<Producto> Productos { get; set; } = new List<Producto>();
       
    }
}
