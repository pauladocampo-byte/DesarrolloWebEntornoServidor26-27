using System;

namespace Ejercicio6
{
    /// <summary>Representa un reproductor MP3 sencillo y sus operaciones principales.</summary>
    public class ReproductorMP3
    {
        private string cancionActual;
        private int volumen;

        public string CancionActual => cancionActual;
        public int Volumen => volumen;
        public bool EstaReproduciendo { get; private set; }

        public ReproductorMP3()
        {
            cancionActual = "";
            volumen = 50;
            EstaReproduciendo = false;
        }

        public void CambiarCancion(string cancion)
        {
            if (string.IsNullOrWhiteSpace(cancion))
                throw new ArgumentException("El nombre de la canción es obligatorio.", nameof(cancion));

            cancionActual = cancion.Trim();
            EstaReproduciendo = false;
        }

        public void Reproducir()
        {
            if (string.IsNullOrWhiteSpace(cancionActual))
                throw new InvalidOperationException("Selecciona una canción antes de reproducir.");

            EstaReproduciendo = true;
        }

        public void Pausar() => EstaReproduciendo = false;
        public void Detener() => EstaReproduciendo = false;

        public void SubirVolumen(int cantidad)
        {
            if (cantidad < 0) throw new ArgumentOutOfRangeException(nameof(cantidad));
            volumen = Math.Min(100, volumen + cantidad);
        }

        public void BajarVolumen(int cantidad)
        {
            if (cantidad < 0) throw new ArgumentOutOfRangeException(nameof(cantidad));
            volumen = Math.Max(0, volumen - cantidad);
        }

        public override string ToString()
        {
            string estado = EstaReproduciendo ? "reproduciendo" : "detenido";
            string cancion = string.IsNullOrEmpty(cancionActual) ? "(sin canción)" : cancionActual;
            return $"{cancion} — volumen {volumen}/100 — {estado}";
        }
    }
}
