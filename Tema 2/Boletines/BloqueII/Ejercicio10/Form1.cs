using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio10
{
    public partial class Form1 : Form
    {
        private readonly NumericUpDown nudJugadores = new NumericUpDown();

        public Form1()
        {
            InitializeComponent();
            Text = "Ruleta rusa";
            Label lblJugadores = new Label { Text = "Número de jugadores (1–6):", AutoSize = true, Left = 230, Top = 165 };
            nudJugadores.Minimum = 1;
            nudJugadores.Maximum = 6;
            nudJugadores.Value = 6;
            nudJugadores.SetBounds(410, 160, 70, 25);
            button1.SetBounds(330, 210, 140, 45);
            Controls.Add(lblJugadores);
            Controls.Add(nudJugadores);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Juego juego = new Juego(decimal.ToInt32(nudJugadores.Value));

            while (!juego.finJuego())
            {
                juego.rondaV2();
            }

            MessageBox.Show("El juego ha terminado");
        }
    }
}
