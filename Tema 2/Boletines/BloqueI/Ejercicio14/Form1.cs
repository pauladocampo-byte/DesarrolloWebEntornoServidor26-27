using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio14
{
    public partial class Form1 : Form
    {
        Cuenta cuenta;
        public Form1()
        {
            InitializeComponent();
            cuenta = new Cuenta(0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(textBox1.Text, out double ingreso) || ingreso <= 0)
            {
                MessageBox.Show("Escribe una cantidad positiva para el depósito.");
                return;
            }

            cuenta.Depositar(ingreso);
            ActualizarSaldo();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(textBox1.Text, out double retirada) || retirada >= 0)
            {
                MessageBox.Show("Escribe una cantidad negativa para la retirada.");
                return;
            }

            cuenta.Retirar(Math.Abs(retirada));
            ActualizarSaldo();
        }

        private void ActualizarSaldo()
        {
            textBox2.Text = cuenta.SaldoActual.ToString("C");
            textBox2.BackColor = cuenta.SaldoActual < 0 ? Color.MistyRose : SystemColors.Window;
            if (cuenta.SaldoActual < 0)
                MessageBox.Show("La cuenta está en números rojos.");
        }
    }
}
