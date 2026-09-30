using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio15
{
    public partial class Form1 : Form
    {
        private readonly Baraja<Enumerados.PalosBarajaEspañola> barajaES = new BarajaEspanhola(false);
        private readonly Baraja<Enumerados.PalosBarajaFrancesa> barajaFRA = new BarajaFrancesa();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            barajaES.Barajar();
            barajaFRA.Barajar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(barajaES.SiguienteCarta()?.ToString() ?? "No quedan cartas españolas.");
            MessageBox.Show(barajaFRA.SiguienteCarta()?.ToString() ?? "No quedan cartas francesas.");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hay " + barajaES.CartasDisponibles + " cartas españolas disponibles");
            MessageBox.Show("Hay " + barajaFRA.CartasDisponibles + " cartas francesas disponibles");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox1.Text, out int numCartas) || numCartas <= 0)
            {
                MessageBox.Show("Introduce un número positivo de cartas.");
                return;
            }

            if (numCartas > barajaES.CartasDisponibles || numCartas > barajaFRA.CartasDisponibles)
            {
                MessageBox.Show("Ambas barajas deben disponer de las cartas solicitadas.");
                return;
            }

            Carta<Enumerados.PalosBarajaEspañola>[] cartas = barajaES.DarCartas(numCartas);
            Carta<Enumerados.PalosBarajaFrancesa>[] cartasFrancesas = barajaFRA.DarCartas(numCartas);
            if (cartas != null && cartasFrancesas != null)
            {
                foreach (Carta<Enumerados.PalosBarajaEspañola> carta in cartas)
                    MessageBox.Show("Española: " + carta.ToString());
                foreach (Carta<Enumerados.PalosBarajaFrancesa> carta in cartasFrancesas)
                    MessageBox.Show("Francesa: " + carta.ToString());
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            barajaES.CartasDelMonton();
            barajaFRA.CartasDelMonton();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            barajaES.MostrarBaraja();
            barajaFRA.MostrarBaraja();
        }
    }
}
