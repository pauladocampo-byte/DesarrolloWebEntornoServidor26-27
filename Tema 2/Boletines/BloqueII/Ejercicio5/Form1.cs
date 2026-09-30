using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(textBox1.Text, out double a)
                || !double.TryParse(textBox2.Text, out double b)
                || !double.TryParse(textBox3.Text, out double c))
            {
                MessageBox.Show("Introduce valores numéricos para los tres coeficientes.");
                return;
            }
            if (a == 0)
            {
                MessageBox.Show("El coeficiente a debe ser distinto de cero.");
                return;
            }

            new Raices(a, b, c).calcular();
        }
    }
}
