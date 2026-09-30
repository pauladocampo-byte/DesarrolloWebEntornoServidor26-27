using System;
using System.Windows.Forms;

namespace Ejercicio15
{
    public abstract class Baraja<T> where T : struct, Enum
    {
        protected Carta<T>[] Cartas;
        protected int PosicionSiguienteCarta;
        protected int NumeroCartas;
        protected int CartasPorPalo;

        public int CartasDisponibles => NumeroCartas - PosicionSiguienteCarta;

        public abstract void CrearBaraja();

        public void Barajar()
        {
            Random aleatorio = new Random();
            for (int i = Cartas.Length - 1; i > 0; i--)
            {
                int posicion = aleatorio.Next(i + 1);
                Carta<T> temporal = Cartas[i];
                Cartas[i] = Cartas[posicion];
                Cartas[posicion] = temporal;
            }

            PosicionSiguienteCarta = 0;
        }

        public Carta<T> SiguienteCarta()
        {
            if (PosicionSiguienteCarta >= NumeroCartas)
            {
                MessageBox.Show("Ya no quedan cartas.");
                return null;
            }

            return Cartas[PosicionSiguienteCarta++];
        }

        public Carta<T>[] DarCartas(int cantidad)
        {
            if (cantidad < 0 || cantidad > CartasDisponibles)
            {
                MessageBox.Show("No hay suficientes cartas para repartir.");
                return null;
            }

            Carta<T>[] cartasRepartidas = new Carta<T>[cantidad];
            for (int i = 0; i < cartasRepartidas.Length; i++)
            {
                cartasRepartidas[i] = SiguienteCarta();
            }

            return cartasRepartidas;
        }

        public void CartasDelMonton()
        {
            if (PosicionSiguienteCarta == 0)
            {
                MessageBox.Show("Aún no se ha sacado ninguna carta.");
                return;
            }

            for (int i = 0; i < PosicionSiguienteCarta; i++)
            {
                MessageBox.Show(Cartas[i].ToString());
            }
        }

        public void MostrarBaraja()
        {
            if (CartasDisponibles == 0)
            {
                MessageBox.Show("No quedan cartas por mostrar.");
                return;
            }

            for (int i = PosicionSiguienteCarta; i < Cartas.Length; i++)
            {
                MessageBox.Show(Cartas[i].ToString());
            }
        }
    }
}
