using System;

namespace Ejercicio15
{
    public class BarajaEspanhola : Baraja<Enumerados.PalosBarajaEspañola>
    {
        private readonly bool incluyeOchoYNueve;

        public BarajaEspanhola(bool incluyeOchoYNueve)
        {
            this.incluyeOchoYNueve = incluyeOchoYNueve;
            CartasPorPalo = incluyeOchoYNueve ? 12 : 10;
            NumeroCartas = CartasPorPalo * 4;
            CrearBaraja();
            Barajar();
        }

        public override void CrearBaraja()
        {
            Cartas = new Carta<Enumerados.PalosBarajaEspañola>[NumeroCartas];
            Enumerados.PalosBarajaEspañola[] palos =
                (Enumerados.PalosBarajaEspañola[])Enum.GetValues(typeof(Enumerados.PalosBarajaEspañola));

            for (int i = 0; i < palos.Length; i++)
            {
                for (int j = 0; j < CartasPorPalo; j++)
                {
                    int numero = incluyeOchoYNueve || j < 7 ? j + 1 : j + 3;
                    Cartas[i * CartasPorPalo + j] = new Carta<Enumerados.PalosBarajaEspañola>(numero, palos[i]);
                }
            }
        }
    }
}
