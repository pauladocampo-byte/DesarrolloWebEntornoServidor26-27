namespace Actividad4.Models
{
    public class Registro
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string CorreoElectronico { get; set; }

        // Propiedad compleja
        public Direccion Direccion { get; set; } = new Direccion();
    }
}
