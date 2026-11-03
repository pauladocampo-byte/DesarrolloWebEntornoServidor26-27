using System.ComponentModel.DataAnnotations;

namespace UD5Modelo.Models.Metadata
{
    public class EquipoMetadata
    {
        [Required, StringLength(50)]
        public string Nombre { get; set; }
        [Required, StringLength(50)]
        public string Pais { get; set; }

        [Range(1850,2100)]
        public int Fundacion { get; set; }
    }
}
