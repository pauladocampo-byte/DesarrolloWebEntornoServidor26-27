using System.ComponentModel.DataAnnotations;

namespace UD5Modelo.Models
{
    public class Friend
    {
        [Required, StringLength(50)]
        public string Name { get; set; }

        [Range(18,100)]
        public int Age { get; set; }

        [Required, StringLength(100)]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Email no válido.")]
        public string Email { get; set; }

        public string Description { get; set; }
    }
}
