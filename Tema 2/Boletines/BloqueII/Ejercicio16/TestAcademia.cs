using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace Ejercicio16
{
    public sealed class TestAcademia
    {
        private readonly List<Pregunta> preguntas = new List<Pregunta>();
        private int indiceSiguiente;

        public int PuntosAcumulados { get; private set; }
        public int NumeroPreguntas => preguntas.Count;
        public int PreguntasRespondidas => indiceSiguiente;
        public Pregunta? PreguntaActual { get; private set; }

        public void CargarPreguntas(string fichero)
        {
            if (string.IsNullOrWhiteSpace(fichero))
                throw new ArgumentException("Indica el fichero de preguntas.", nameof(fichero));

            string[] lineas = File.ReadAllLines(fichero);
            List<Pregunta> cargadas = new List<Pregunta>();
            int linea = 0;
            while (linea < lineas.Length)
            {
                while (linea < lineas.Length && string.IsNullOrWhiteSpace(lineas[linea])) linea++;
                if (linea == lineas.Length) break;

                string textoPregunta = LeerMarcador(lineas[linea++], ";P;", linea);
                List<string> opciones = new List<string>();
                while (linea < lineas.Length && !lineas[linea].TrimStart().StartsWith(";R;", StringComparison.Ordinal))
                {
                    if (!string.IsNullOrWhiteSpace(lineas[linea])) opciones.Add(lineas[linea].Trim());
                    linea++;
                }

                if (linea >= lineas.Length)
                    throw new FormatException("Falta el marcador ;R; después de una pregunta.");

                string respuestaTexto = LeerMarcador(lineas[linea++], ";R;", linea);
                if (!int.TryParse(respuestaTexto, NumberStyles.Integer, CultureInfo.InvariantCulture, out int respuesta))
                    throw new FormatException("El índice de la opción correcta debe ser un entero.");
                if (linea >= lineas.Length || !int.TryParse(lineas[linea].Trim(), NumberStyles.Integer,
                    CultureInfo.InvariantCulture, out int puntos))
                    throw new FormatException("Cada pregunta debe indicar sus puntos como entero.");
                linea++;

                try
                {
                    cargadas.Add(new Pregunta(textoPregunta, opciones, respuesta, puntos));
                }
                catch (ArgumentException ex)
                {
                    throw new FormatException($"Pregunta en torno a la línea {linea} no válida: {ex.Message}", ex);
                }
            }

            if (cargadas.Count == 0)
                throw new FormatException("El fichero no contiene preguntas.");

            preguntas.Clear();
            preguntas.AddRange(cargadas);
            ReiniciarTest();
        }

        private static string LeerMarcador(string linea, string marcador, int numeroLinea)
        {
            string texto = linea.Trim();
            if (!texto.StartsWith(marcador, StringComparison.Ordinal))
                throw new FormatException($"Se esperaba «{marcador}» en la línea {numeroLinea}.");
            string contenido = texto.Substring(marcador.Length).Trim();
            if (contenido.Length == 0)
                throw new FormatException($"El marcador {marcador} no puede estar vacío.");
            return contenido;
        }

        public Pregunta? SiguientePregunta()
        {
            if (indiceSiguiente >= preguntas.Count)
            {
                PreguntaActual = null;
                return null;
            }

            PreguntaActual = preguntas[indiceSiguiente++];
            return PreguntaActual;
        }

        public bool ComprobarRespuesta(int respuestaUsuario)
        {
            Pregunta pregunta = PreguntaActual
                ?? throw new InvalidOperationException("No hay una pregunta activa.");

            bool correcta = pregunta.ComprobarRespuesta(respuestaUsuario);
            if (correcta) PuntosAcumulados += pregunta.Puntos;
            return correcta;
        }

        public void ReiniciarTest()
        {
            indiceSiguiente = 0;
            PuntosAcumulados = 0;
            PreguntaActual = null;
        }
    }
}
