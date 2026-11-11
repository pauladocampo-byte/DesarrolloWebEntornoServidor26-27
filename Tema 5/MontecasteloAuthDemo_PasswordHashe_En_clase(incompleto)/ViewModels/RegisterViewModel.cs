using System.ComponentModel.DataAnnotations;

namespace MontecasteloAuthDemo.ViewModels
{
    public class RegisterViewModel
    {
        [Required, Display(Name = "Usuario"), StringLength(40)]
        public string UserName { get; set; } = default!;

        [Required, DataType(DataType.Password), Display(Name = "Contraseña")]
        [StringLength(100, MinimumLength = 6)]
        public string Password { get; set; } = default!;

        [Required, DataType(DataType.Password), Display(Name = "Confirmar contraseña")]
        [Compare("Password", ErrorMessage = "Las contraseñas no coinciden.")]
        public string ConfirmPassword { get; set; } = default!;

        [Display(Name = "Rol")]
        public string Role { get; set; } = "User";
    }
}
