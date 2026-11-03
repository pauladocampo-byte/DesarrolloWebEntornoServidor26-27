using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using UD5Modelo.Models.Metadata;

namespace UD5Modelo.Models
{
    [ModelMetadataType(typeof(FutbolistaMetadata))]
    public class Futbolista : IValidatableObject
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string Apellido { get; set; }
        public string? Dni { get; set; }
        public int? Edad { get; set; }   
        public int? Dorsal { get; set; }
        public int MinutosJugados { get; set; }

        public  bool EnActivo { get; set; }

        [Precision(18, 2)]
        public decimal? PrecioMercado { get; set; }

        public string Telefono { get; set; }

        public int? Minutos { get; set; }        // > 0 si EnActivo

        public int? EquipoId { get; set; }   // requerido si EnActivo 
        public Equipo? Equipo { get; set; }   // navegación


        public IEnumerable<ValidationResult> Validate(ValidationContext context)
        {
            if (!EnActivo) yield break; // Solo aplican si está en activo

            if (Equipo is null)
                yield return new ValidationResult("Debe tener un CódigoEquipo.", new[] { nameof(Equipo) });

            if (Edad is null || Edad >= 45)
                yield return new ValidationResult("Debe tener Edad menor de 45.", new[] { nameof(Edad) });

            if (Minutos is null || Minutos <= 0)
                yield return new ValidationResult("Debe tener Minutos > 0.", new[] { nameof(Minutos) });

            if (Dorsal is null || Dorsal < 1 || Dorsal > 25)
                yield return new ValidationResult("Debe tener un Dorsal entre 1 y 25.", new[] { nameof(Dorsal) });

            if (PrecioMercado is null || PrecioMercado <= 0)
                yield return new ValidationResult("Debe tener PrecioMercado (> 0).", new[] { nameof(PrecioMercado) });
        }
    }
}
