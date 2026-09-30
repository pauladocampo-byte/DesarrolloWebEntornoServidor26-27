using System;
using System.Collections.Generic;
using System.Text;

namespace Ejercicio16
{
    public sealed class Pregunta
    {
        private readonly List<Opcion> opciones;

        public string Texto { get; }
        public IReadOnlyList<Opcion> Opciones => opciones.AsReadOnly();
        public int NumeroOpcionCorrecta { get; }
        public int Puntos { get; }

        public Pregunta(string texto, IEnumerable<string> opciones, int numeroOpcionCorrecta, int puntos)
        {
            if (string.IsNullOrWhiteSpace(texto))
                throw new ArgumentException("El texto de la pregunta es obligatorio.", nameof(texto));
            if (opciones == null) throw new ArgumentNullException(nameof(opciones));

            List<string> textosOpciones = new List<string>(opciones);
            if (textosOpciones.Count < 2 || textosOpciones.Count > 4)
                throw new ArgumentException("Una pregunta debe tener entre dos y cuatro opciones.", nameof(opciones));
            if (numeroOpcionCorrecta < 1 || numeroOpcionCorrecta > textosOpciones.Count)
                throw new ArgumentOutOfRangeException(nameof(numeroOpcionCorrecta));
            if (puntos < 0) throw new ArgumentOutOfRangeException(nameof(puntos));

            Texto = texto.Trim();
            NumeroOpcionCorrecta = numeroOpcionCorrecta;
            Puntos = puntos;
            this.opciones = new List<Opcion>();
            for (int i = 0; i < textosOpciones.Count; i++)
                this.opciones.Add(new Opcion(textosOpciones[i], i + 1 == numeroOpcionCorrecta));
        }

        public bool ComprobarRespuesta(int respuestaUsuario)
        {
            return respuestaUsuario >= 1
                && respuestaUsuario <= opciones.Count
                && opciones[respuestaUsuario - 1].EsCorrecta;
        }

        public string MostrarPregunta()
        {
            StringBuilder texto = new StringBuilder(Texto);
            for (int i = 0; i < opciones.Count; i++)
                texto.AppendLine().Append(i + 1).Append(") ").Append(opciones[i].Texto);
            return texto.ToString();
        }

        public override string ToString() => MostrarPregunta();
    }
}
