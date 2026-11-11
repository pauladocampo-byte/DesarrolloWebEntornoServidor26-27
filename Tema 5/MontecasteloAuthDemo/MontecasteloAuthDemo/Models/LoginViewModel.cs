using System.ComponentModel.DataAnnotations;

namespace MontecasteloAuthDemo.Models
{
    public class LoginViewModel
    {
        [Required, Display(Name = "Usuario")]
        public string UserName { get; set; } = default!;

        [Required, DataType(DataType.Password), Display(Name = "Contraseña")]
        public string Password { get; set; } = default!;
    }
}
