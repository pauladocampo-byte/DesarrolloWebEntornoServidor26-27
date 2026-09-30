using System;

namespace Ejercicio15
{
    public class BarajaFrancesa : Baraja<Enumerados.PalosBarajaFrancesa>
    {
        public BarajaFrancesa()
        {
            CartasPorPalo = 13;
            NumeroCartas = CartasPorPalo * 4;
            CrearBaraja();
            Barajar();
        }

        public override void CrearBaraja()
        {
            Cartas = new Carta<Enumerados.PalosBarajaFrancesa>[NumeroCartas];
            Enumerados.PalosBarajaFrancesa[] palos =
                (Enumerados.PalosBarajaFrancesa[])Enum.GetValues(typeof(Enumerados.PalosBarajaFrancesa));

            for (int i = 0; i < palos.Length; i++)
            {
                for (int numero = 1; numero <= CartasPorPalo; numero++)
                {
                    Cartas[i * CartasPorPalo + numero - 1] =
                        new Carta<Enumerados.PalosBarajaFrancesa>(numero, palos[i]);
                }
            }
        }

        public bool CartaRoja(Carta<Enumerados.PalosBarajaFrancesa> carta)
        {
            return carta.Palo == Enumerados.PalosBarajaFrancesa.CORAZONES
                || carta.Palo == Enumerados.PalosBarajaFrancesa.DIAMANTES;
        }

        public bool CartaNegra(Carta<Enumerados.PalosBarajaFrancesa> carta)
        {
            return carta.Palo == Enumerados.PalosBarajaFrancesa.TREBOLES
                || carta.Palo == Enumerados.PalosBarajaFrancesa.PICAS;
        }
    }
}
