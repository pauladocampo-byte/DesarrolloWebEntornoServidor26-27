using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio12
{
    public partial class Form1 : Form
    {
        BindingList<Producto> listaProductos = new BindingList<Producto>();
        public Form1()
        {
            InitializeComponent();
            lstProductos.DataSource = listaProductos;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nombre;
            double precio;
            int diasACaducar;
            string tipo;
            string tipoProducto;
            Producto producto;

            tipoProducto = comboBox1.Text;
            nombre = textBox1.Text;
            if (string.IsNullOrWhiteSpace(nombre)
                || !double.TryParse(textBox2.Text, out precio) || precio < 0
                || !int.TryParse(textBox3.Text, out diasACaducar) || diasACaducar < 0)
            {
                MessageBox.Show("Indica nombre, un precio no negativo y días enteros no negativos.");
                return;
            }
            tipo = textBox4.Text;

            if (tipoProducto == "PRODUCTO")
            {
                producto = new Producto(nombre, precio);
            }
            else if (tipoProducto == "PERECEDERO")
            {
                producto = new Perecedero(diasACaducar, nombre, precio);
            }
            else if (tipoProducto == "NO PERECEDERO")
            {
                if (string.IsNullOrWhiteSpace(tipo))
                {
                    MessageBox.Show("Indica el tipo del producto no perecedero.");
                    return;
                }
                producto = new NoPerecedero(tipo, nombre, precio);
            }
            else
            {
                MessageBox.Show("Selecciona un tipo de producto.");
                return;
            }
            listaProductos.Add(producto);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!(lstProductos.SelectedItem is Producto producto))
            {
                MessageBox.Show("Selecciona un producto.");
                return;
            }
            if (!int.TryParse(textBox5.Text, out int cantidad) || cantidad <= 0)
            {
                MessageBox.Show("Introduce una cantidad entera positiva.");
                return;
            }
            MessageBox.Show("Precio final: " + producto.calcular(cantidad).ToString("C"));
        }
    }
}
