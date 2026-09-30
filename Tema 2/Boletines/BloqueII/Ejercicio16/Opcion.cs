using System;

namespace Ejercicio16
{
    public sealed class Opcion
    {
        public string Texto { get; }
        public bool EsCorrecta { get; }

        public Opcion(string texto, bool esCorrecta)
        {
            if (string.IsNullOrWhiteSpace(texto))
                throw new ArgumentException("El texto de la opción es obligatorio.", nameof(texto));

            Texto = texto.Trim();
            EsCorrecta = esCorrecta;
        }
    }
}
