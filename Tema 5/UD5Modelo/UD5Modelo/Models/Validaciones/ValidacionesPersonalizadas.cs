using System.ComponentModel.DataAnnotations;

namespace UD5Modelo.Models.Validaciones
{
    public class ValidacionesPersonalizadas
    {
        public static ValidationResult ValidarDni(string? dni)
        {
            if (string.IsNullOrEmpty(dni))
            {
                return ValidationResult.Success;//Permitir cadenas vacías
            }
            // Ejemplo simple de validación de DNI (8 dígitos seguidos de una letra)
            if (dni.Length == 9 && int.TryParse(dni.Substring(0, 8), out _) && char.IsLetter(dni[8]))
            {
                return ValidationResult.Success!;
            }
            return new ValidationResult("El DNI no es válido. Debe tener 8 dígitos seguidos de una letra.");
        }
    }
}
