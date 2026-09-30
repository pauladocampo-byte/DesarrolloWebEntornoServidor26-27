using System.Windows.Forms;

namespace Ejercicio13
{
    /// <summary>Guarda el valor actual y los extremos observados desde que se creó.</summary>
    public class Valores
    {
        private bool hayValor;

        public int Valor { get; private set; }
        public int MenorValor { get; private set; }
        public int MayorValor { get; private set; }

        public void NuevoValor(int valor)
        {
            Valor = valor;
            if (!hayValor)
            {
                MenorValor = valor;
                MayorValor = valor;
                hayValor = true;
                return;
            }

            if (valor < MenorValor) MenorValor = valor;
            if (valor > MayorValor) MayorValor = valor;
        }

        public void Comparar()
        {
            MessageBox.Show($"Valor actual: {Valor}; mínimo alcanzado: {MenorValor}; máximo alcanzado: {MayorValor}");
        }
    }
}
