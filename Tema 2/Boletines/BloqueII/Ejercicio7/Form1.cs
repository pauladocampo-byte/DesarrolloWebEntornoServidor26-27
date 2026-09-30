using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio7
{
    public partial class Form1 : Form
    {
        BindingList<Pelicula> listaPeliculas = new BindingList<Pelicula>();
        BindingList<Espectador> listaEspectadores = new BindingList<Espectador>();
        BindingList<Cine> listaCines = new BindingList<Cine>();
        private readonly Random generadorAleatorio = new Random();
        public Form1()
        {
            InitializeComponent();
            lstPeliculas.DataSource = listaPeliculas;
            lstEspectadores.DataSource = listaEspectadores;
            lstCines.DataSource = listaCines;
            comboBox1.DataSource = listaPeliculas;

            Label lblCantidad = new Label { Text = "Espectadores a generar:", AutoSize = true, Left = 450, Top = 246 };
            NumericUpDown nudCantidad = new NumericUpDown
            {
                Name = "nudCantidadEspectadores",
                Minimum = 1,
                Maximum = 500,
                Value = 50,
                Left = 590,
                Top = 242,
                Width = 65
            };
            Button btnSimular = new Button
            {
                Text = "Generar y sentar",
                Left = 664,
                Top = 240,
                Width = 125
            };
            btnSimular.Click += (sender, args) => SimularEspectadores(decimal.ToInt32(nudCantidad.Value));
            Controls.Add(lblCantidad);
            Controls.Add(nudCantidad);
            Controls.Add(btnSimular);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String titulo;
            int duracion;
            int edadMinima;
            String director;

            titulo = textBox1.Text;
            int.TryParse(textBox2.Text, out duracion);
            int.TryParse(textBox3.Text, out edadMinima);
            director = textBox4.Text;

            Pelicula peli = new Pelicula(titulo, duracion, edadMinima, director);

            listaPeliculas.Add(peli);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String nombre;
            int edad;
            double dinero;

            nombre = textBox8.Text;
            int.TryParse(textBox7.Text, out edad);
            double.TryParse(textBox6.Text, out dinero);

            Espectador fulano = new Espectador(nombre, edad, dinero);

            listaEspectadores.Add(fulano);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int filas;
            int columnas;
            double precio;
            Pelicula peli;

            int.TryParse(textBox10.Text, out filas);
            int.TryParse(textBox9.Text, out columnas);
            double.TryParse(textBox5.Text, out precio);

            peli = (Pelicula)comboBox1.SelectedItem;

            Cine cine = new Cine(filas, columnas, precio, peli);

            listaCines.Add(cine);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!(lstEspectadores.SelectedItem is Espectador espectador)
                || !(lstCines.SelectedItem is Cine cine))
            {
                MessageBox.Show("Selecciona un espectador y un cine.");
                return;
            }

            if (cine.sentarAleatoriamente(espectador, out Asiento asiento))
            {
                MessageBox.Show($"{espectador.getNombre()} se sienta en el asiento {asiento.getFila()}{asiento.getLetra()}.");
                lstEspectadores.Refresh();
                lstCines.Refresh();
            }
            else
                MessageBox.Show("No se puede sentar: comprueba la edad, el saldo y que haya asientos libres.");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (lstCines.SelectedItem is Cine cine)
                cine.mostrar();
            else
                MessageBox.Show("Selecciona un cine.");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (lstEspectadores.SelectedItem is Espectador espectador)
                MessageBox.Show(espectador.toString());
            else
                MessageBox.Show("Selecciona un espectador.");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (lstPeliculas.SelectedItem is Pelicula peli)
                MessageBox.Show(peli.toString());
            else
                MessageBox.Show("Selecciona una película.");
        }

        private void SimularEspectadores(int cantidad)
        {
            if (!(lstCines.SelectedItem is Cine cine))
            {
                MessageBox.Show("Selecciona un cine antes de iniciar la simulación.");
                return;
            }

            int sentados = 0;
            for (int i = 0; i < cantidad; i++)
            {
                Espectador espectador = new Espectador(
                    $"Espectador {listaEspectadores.Count + 1}",
                    generadorAleatorio.Next(5, 81),
                    generadorAleatorio.Next(0, 101));

                listaEspectadores.Add(espectador);
                if (cine.sentarAleatoriamente(espectador, out _))
                    sentados++;
            }

            lstEspectadores.Refresh();
            lstCines.Refresh();
            MessageBox.Show($"Simulación terminada. Se sentaron {sentados} de {cantidad} espectadores.");
        }
    }
}
