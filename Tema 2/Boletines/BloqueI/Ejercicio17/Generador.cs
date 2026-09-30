using System;

namespace Ejercicio17
{
    /// <summary>Generador congruencial lineal definido en el enunciado.</summary>
    public class Generador
    {
        private int numeroAnterior;

        public Generador(int semilla)
        {
            if (semilla < 0 || semilla > 65535)
                throw new ArgumentOutOfRangeException(nameof(semilla), "La semilla debe estar entre 0 y 65535.");
            numeroAnterior = semilla;
        }

        public int GenerarNumero()
        {
            numeroAnterior = (int)(((long)numeroAnterior * 25173 + 13849) % 65536);
            return numeroAnterior;
        }
    }
}
