using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio4
{
    public partial class Form1 : Form
    {
        BindingList<Electrodomestico> listaElectrodomesticos = new BindingList<Electrodomestico>();
        public Form1()
        {
            InitializeComponent();
            lstElectrodomesticos.DataSource = listaElectrodomesticos;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!TryLeerDatosBase(out double precioBase, out double peso, out char consumoEnergetico, out string color)) return;
            if (!int.TryParse(txtCarga.Text, out int carga) || carga < 0)
            {
                MessageBox.Show("La carga debe ser un entero no negativo.");
                return;
            }

            Lavadora lavadora = new Lavadora(precioBase, peso, consumoEnergetico, color, carga);

            listaElectrodomesticos.Add(lavadora);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!TryLeerDatosBase(out double precioBase, out double peso, out char consumoEnergetico, out string color)) return;
            if (!int.TryParse(txtResolucion.Text, out int resolucion) || resolucion <= 0)
            {
                MessageBox.Show("La resolución debe ser un entero positivo.");
                return;
            }
            bool sintonizadorTDT = string.Equals(cbTDT.Text, "Sí", StringComparison.OrdinalIgnoreCase);

            Television television = new Television(precioBase, peso, consumoEnergetico, color, resolucion, sintonizadorTDT);

            listaElectrodomesticos.Add(television);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (!(lstElectrodomesticos.SelectedItem is Electrodomestico objeto))
            {
                MessageBox.Show("Selecciona un electrodoméstico.");
                return;
            }
            if (objeto is Lavadora)
            {
                Lavadora lavadora = (Lavadora)objeto;
                MessageBox.Show("El precio final de la lavadora es: " + lavadora.precioFinal().ToString("C"));
            }
            else
            {
                Television television = (Television)objeto;
                MessageBox.Show("El precio final de la televisión es: " + television.precioFinal().ToString("C"));
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            double precioTelevisiones = 0;
            double precioLavadoras = 0;

            foreach (Electrodomestico item in listaElectrodomesticos)
            {
                if (item is Lavadora)
                {
                    precioLavadoras += ((Lavadora)item).precioFinal();
                }
                else if (item is Television)
                {
                    precioTelevisiones += ((Television)item).precioFinal();
                }
            }
            MessageBox.Show("El precio de las lavadoras es: " + precioLavadoras.ToString("C"));
            MessageBox.Show("El precio de las televisiones es: " + precioTelevisiones.ToString("C"));
            MessageBox.Show("El precio total es: " + (precioLavadoras + precioTelevisiones).ToString("C"));
        }

        private bool TryLeerDatosBase(out double precioBase, out double peso, out char consumoEnergetico, out string color)
        {
            precioBase = 0;
            peso = 0;
            consumoEnergetico = '\0';
            color = txtColor.Text.Trim();
            if (!double.TryParse(txtPrecioBase.Text, out precioBase) || precioBase < 0
                || !double.TryParse(txtPeso.Text, out peso) || peso < 0)
            {
                MessageBox.Show("El precio base y el peso deben ser números no negativos.");
                return false;
            }

            if (txtConsumoEnergetico.Text.Trim().Length > 0)
                char.TryParse(txtConsumoEnergetico.Text.Trim(), out consumoEnergetico);
            return true;
        }
    }
}
