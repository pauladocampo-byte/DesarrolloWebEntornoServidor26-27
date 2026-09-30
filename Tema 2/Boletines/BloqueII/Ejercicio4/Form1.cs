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
        BindingList<Libro> listaLibros = new BindingList<Libro>();
        public Form1()
        {
            InitializeComponent();
            lstLibros.DataSource = listaLibros;
        }

        private void btnCrearLibro_Click(object sender, EventArgs e)
        {
            string titulo;
            string autor;
            titulo = txtTitulo.Text;
            autor = txtAutor.Text;
            if (!int.TryParse(txtISBN.Text, out int ISBN)
                || !int.TryParse(txtNumPaginas.Text, out int numPaginas)
                || ISBN <= 0 || numPaginas <= 0
                || string.IsNullOrWhiteSpace(titulo) || string.IsNullOrWhiteSpace(autor))
            {
                MessageBox.Show("Completa los datos e introduce ISBN y páginas positivos.");
                return;
            }

            Libro libro = new Libro(ISBN, titulo, autor, numPaginas);
            listaLibros.Add(libro);
        }

        private void lstLibros_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int indiceSeleccionado = lstLibros.SelectedIndex;
            if (indiceSeleccionado < 0) return;
            MessageBox.Show(listaLibros[indiceSeleccionado].toString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listaLibros.Count == 0)
            {
                MessageBox.Show("Crea algún libro antes de buscar el de más páginas.");
                return;
            }
            Libro libroConMasPaginas = null;
            foreach (Libro libro in listaLibros)
            {
                if (libroConMasPaginas == null) libroConMasPaginas = libro;
                if (libroConMasPaginas.compareTo(libro) == 1)
                {
                    libroConMasPaginas = libro;
                }
            }
            MessageBox.Show(libroConMasPaginas.toString());
        }
    }
}
