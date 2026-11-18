namespace Actividad1.Models
{
    public class Blog
    {
        int id;
        string contenido;

        public Blog()
        {
        }

        public int Id { get => id; set => id = value; }
        public string Contenido { get => contenido; set => contenido = value; }
    }
}
