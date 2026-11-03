using System.ComponentModel.DataAnnotations;

namespace UD5Modelo.Models.Validaciones
{
    public class ValidarDNIAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            var dni = (value as string)?.Trim().ToUpperInvariant();

            if (string.IsNullOrEmpty(dni))
            {
                return true;//Permitir cadenas vacías
            }
            // Ejemplo simple de validación de DNI (8 dígitos seguidos de una letra)
            if (dni.Length == 9 && int.TryParse(dni.Substring(0, 8), out _) && char.IsLetter(dni[8]))
            {
                return true;
            }
            return false;
            
        }
    }

}
