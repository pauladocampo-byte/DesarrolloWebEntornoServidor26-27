using System.ComponentModel.DataAnnotations;

namespace MontecasteloAuthDemo.Dtos
{
    public class CreateUserDto
    {
        [Required, StringLength(40)]
        public string NombreUsuario { get; set; } = default!;

        [Required, StringLength(100, MinimumLength = 6), DataType(DataType.Password)]
        public string Password { get; set; } = default!;

        [Required, Compare(nameof(Password)), DataType(DataType.Password)]
        public string ConfirmPassword { get; set; } = default!;

        [Required, StringLength(20)]
        public string Rol { get; set; } = "User";
    }
}
