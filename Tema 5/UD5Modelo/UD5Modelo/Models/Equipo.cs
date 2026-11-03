using System.ComponentModel.DataAnnotations;
using UD5Modelo.Models.Metadata;

namespace UD5Modelo.Models
{
    [MetadataType(typeof(EquipoMetadata))]
    public class Equipo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Pais { get; set; }
        public int Fundacion { get; set; }

        public ICollection<Futbolista> Futbolistas { get; set; } = [];
    }
}
