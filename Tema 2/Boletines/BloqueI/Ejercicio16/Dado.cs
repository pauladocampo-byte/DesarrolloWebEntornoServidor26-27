using System;

namespace Ejercicio16
{
    public class Dado
    {
        private static readonly Random GeneradorAleatorio = new Random();
        private int valor;

        public Dado()
        {
            valor = 0;
        }

        public Dado(int valor)
        {
            Valor = valor;
        }

        public int Valor
        {
            get => valor;
            private set
            {
                if (value < 1 || value > 6)
                    throw new ArgumentOutOfRangeException(nameof(value), "El dado solo puede mostrar valores del 1 al 6.");
                valor = value;
            }
        }

        public void LanzarFijo() => Valor = 6;

        public void LanzarIncremental()
        {
            Valor = valor >= 6 ? 1 : valor + 1;
        }

        public void LanzarAleatorio()
        {
            Valor = GeneradorAleatorio.Next(1, 7);
        }
    }
}
