using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using UD5Modelo.Models.Validaciones;

namespace UD5Modelo.Models.Metadata
{
    public class FutbolistaMetadata
    {
        [Required, StringLength(6)]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio."),StringLength(6)]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "El DNI es obligatorio.")] 
        //[CustomValidation(typeof(ValidacionesPersonalizadas), "ValidarDni")]
        [ValidarDNI(ErrorMessage = "DNI no válido")]
        public string? Dni { get; set; }
        [Range(16,32, ErrorMessage = "La edad debe estar entre 16 y 32 años.")]
        public int Edad { get; set; }

        [Range(1,99, ErrorMessage = "El dorsal debe estar entre 1 y 99.")]
        public int Dorsal { get; set; }

        [Range(0,int.MaxValue, ErrorMessage = "Los minutos jugados no pueden ser negativos.")]
        public int MinutosJugados { get; set; }

        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        public decimal PrecioMercado { get; set; }

        [Phone]
        public string Telefono { get; set; }

    }
}
