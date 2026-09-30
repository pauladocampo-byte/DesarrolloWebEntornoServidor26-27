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
        Almacen a = new Almacen();
        private readonly TextBox txtMarcaConsulta = new TextBox();
        private readonly NumericUpDown nudColumnaConsulta = new NumericUpDown();

        public Form1()
        {
            InitializeComponent();
            ClientSize = new Size(800, 500);
            label1.Text = "ID generado automáticamente";
            textBox1.ReadOnly = true;
            Label lblMarca = new Label { Text = "Marca a consultar", AutoSize = true, Left = 75, Top = 414 };
            txtMarcaConsulta.SetBounds(180, 410, 100, 24);
            Button btnPrecioMarca = new Button { Text = "Precio por marca", Left = 346, Top = 407, Width = 120 };
            btnPrecioMarca.Click += (sender, args) =>
            {
                string marca = txtMarcaConsulta.Text.Trim();
                if (marca.Length == 0)
                {
                    MessageBox.Show("Escribe una marca.");
                    return;
                }
                MessageBox.Show($"Precio de {marca}: {a.calcularPrecioBebidas(marca):C}");
            };

            Label lblColumna = new Label { Text = "Estantería (columna)", AutoSize = true, Left = 75, Top = 456 };
            nudColumnaConsulta.Minimum = 0;
            nudColumnaConsulta.Maximum = 4;
            nudColumnaConsulta.SetBounds(205, 452, 65, 24);
            Button btnPrecioEstanteria = new Button { Text = "Precio por estantería", Left = 346, Top = 449, Width = 140 };
            btnPrecioEstanteria.Click += (sender, args) =>
                MessageBox.Show($"Precio de la estantería {nudColumnaConsulta.Value}: {a.calcularPrecioBebidas(decimal.ToInt32(nudColumnaConsulta.Value)):C}");

            Controls.AddRange(new Control[] { lblMarca, txtMarcaConsulta, btnPrecioMarca,
                lblColumna, nudColumnaConsulta, btnPrecioEstanteria });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bebida b;
            int id;
            double cantidad;
            double precio;
            String marca;
            string manantial;
            double porcentajeAzucar;
            bool enPromocion = false;
            string tipoProducto = comboBox1.Text;

            int.TryParse(textBox1.Text, out id);
            double.TryParse(textBox2.Text, out cantidad);
            double.TryParse(textBox3.Text, out precio);
            marca = textBox4.Text;
            manantial = textBox5.Text;
            double.TryParse(textBox6.Text, out porcentajeAzucar);
            enPromocion = checkBox1.Checked;

            if (tipoProducto == "AGUA MINERAL")
            {
                b = new AguaMineral(manantial, cantidad, precio, marca);
            }
            else if (tipoProducto == "BEBIDA AZUCARADA")
            {
                b = new BebidaAzucarada(porcentajeAzucar, enPromocion, cantidad, precio, marca);
            }
            else
            {
                b = new Bebida(cantidad, precio, marca);
            }
            if (a.agregarBebida(b))
                textBox1.Text = b.getId().ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int idSeleccionado;
            int.TryParse(textBox7.Text, out idSeleccionado);
            a.eliminarBebida(idSeleccionado);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Precio de todas las bebidas: " + a.calcularPrecioBebidas().ToString("C"));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            a.mostrarBebidas();
        }
    }
}
