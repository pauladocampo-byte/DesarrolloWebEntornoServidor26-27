using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio13
{
    public partial class Form1 : Form
    {
        private readonly Valores valores = new Valores();

        public Form1()
        {
            InitializeComponent();
            ActualizarValor(trackBar1.Value);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ActualizarValor(trackBar1.Value);
            valores.Comparar();

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            ActualizarValor(trackBar1.Value);
        }

        private void ActualizarValor(int valor)
        {
            valores.NuevoValor(valor);
            textBox1.Text = valores.MenorValor.ToString();
            textBox2.Text = valores.MayorValor.ToString();
        }
    }
}
