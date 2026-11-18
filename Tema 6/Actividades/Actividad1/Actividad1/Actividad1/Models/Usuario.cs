namespace Actividad1.Models
{
    public class Usuario
    {
        int id;
        string username;

        public Usuario()
        {
        }

        public int Id { get => id; set => id = value; }
        public string Username { get => username; set => username = value; }
    }
}
