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
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Juego nuevo = new Juego(0);

            nuevo.incrementar();
            MessageBox.Show("Puntuación: " + nuevo.Puntuacion);
            nuevo.reducir();
            MessageBox.Show("Tras reducir: " + nuevo.Puntuacion);
            nuevo.inicializar();
            MessageBox.Show("Tras inicializar: " + nuevo.Puntuacion);
        }
    }
}
