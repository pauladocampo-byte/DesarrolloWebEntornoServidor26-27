using System.ComponentModel.DataAnnotations;

namespace MontecasteloAuthDemo.Dtos
{
    public class ResetPasswordDto
    {
        [Required, StringLength(100, MinimumLength = 6), DataType(DataType.Password)]
        public string NewPassword { get; set; } = default!;

        [Required, Compare(nameof(NewPassword)), DataType(DataType.Password)]
        public string ConfirmNewPassword { get; set; } = default!;
    }
}
