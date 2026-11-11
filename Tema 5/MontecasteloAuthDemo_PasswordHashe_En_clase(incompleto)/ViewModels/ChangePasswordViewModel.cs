using System.ComponentModel.DataAnnotations;

namespace MontecasteloAuthDemo.ViewModels
{
    public class ChangePasswordViewModel
    {
        [Required, DataType(DataType.Password), Display(Name = "Contraseña actual")]
        public string CurrentPassword { get; set; } = default!;

        [Required, DataType(DataType.Password), Display(Name = "Nueva contraseña")]
        [StringLength(100, MinimumLength = 6)]
        public string NewPassword { get; set; } = default!;

        [Required, DataType(DataType.Password), Display(Name = "Confirmar nueva contraseña")]
        [Compare("NewPassword", ErrorMessage = "Las contraseñas no coinciden.")]
        public string ConfirmNewPassword { get; set; } = default!;
    }
}
