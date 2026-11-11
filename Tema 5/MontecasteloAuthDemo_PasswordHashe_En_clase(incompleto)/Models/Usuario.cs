using System.ComponentModel.DataAnnotations;

namespace MontecasteloAuthDemo.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required, MaxLength(40)]
        public string NombreUsuario { get; set; } = default!;

        [Required, MaxLength(256)]
        public string PasswordHash { get; set; } = default!;

        [Required, MaxLength(20)]
        public string Rol { get; set; } = "User";
    }
}
