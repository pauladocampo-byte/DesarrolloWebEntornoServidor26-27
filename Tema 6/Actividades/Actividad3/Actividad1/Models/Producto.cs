namespace Actividad1.Models
{
    public class Producto
    {
        int id;
        string nombre;
        double precio;

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public double Precio { get => precio; set => precio = value; }
    }
}
