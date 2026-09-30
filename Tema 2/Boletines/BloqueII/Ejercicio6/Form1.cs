using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio6
{
    public partial class Form1 : Form
    {
        BindingList<Alumno> listaAlumnos = new BindingList<Alumno>();
        BindingList<Profesor> listaProfesores = new BindingList<Profesor>();
        BindingList<Aula> listaAulas = new BindingList<Aula>();
        private readonly ComboBox cmbAsignaturaAula = new ComboBox();
        private int siguienteIdAula = 1;

        public Form1()
        {
            InitializeComponent();
            lstAlumnos.DataSource = listaAlumnos;
            lstProfesores.DataSource = listaProfesores;
            lstAulas.DataSource = listaAulas;
            lstAlumnos.SelectionMode = SelectionMode.MultiExtended;
            cmbAsignaturaAula.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAsignaturaAula.Items.AddRange(Constantes.ASIGNATURAS);
            cmbAsignaturaAula.SelectedIndex = 0;
            cmbAsignaturaAula.SetBounds(300, 231, 135, 24);
            Controls.Add(cmbAsignaturaAula);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!ValidarDatosPersona(12, 17, out string nombre, out char sexo, out int edad)) return;

            Alumno alumno = new Alumno();
            alumno.setNombre(nombre);
            alumno.setSexo(sexo);
            alumno.setEdad(edad);

            listaAlumnos.Add(alumno);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!ValidarDatosPersona(25, 65, out string nombre, out char sexo, out int edad)) return;

            Profesor profe = new Profesor();
            profe.setNombre(nombre);
            profe.setSexo(sexo);
            profe.setEdad(edad);

            listaProfesores.Add(profe);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!(lstProfesores.SelectedItem is Profesor profesor))
            {
                MessageBox.Show("Selecciona un profesor antes de crear el aula.");
                return;
            }

            List<Alumno> alumnosSeleccionados = new List<Alumno>();
            foreach (object elemento in lstAlumnos.SelectedItems)
                alumnosSeleccionados.Add((Alumno)elemento);

            if (alumnosSeleccionados.Count == 0 || alumnosSeleccionados.Count > 20)
            {
                MessageBox.Show("Selecciona entre 1 y 20 alumnos para el aula.");
                return;
            }

            Aula aula = new Aula(siguienteIdAula++, profesor, alumnosSeleccionados,
                cmbAsignaturaAula.SelectedItem.ToString());
            listaAulas.Add(aula);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (lstAulas.SelectedItem is Aula aulaSeleccionada)
                MessageBox.Show(aulaSeleccionada.ToString());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!(lstAulas.SelectedItem is Aula aulaSeleccionada))
            {
                MessageBox.Show("Selecciona un aula.");
                return;
            }

            if (aulaSeleccionada.darClase())
                aulaSeleccionada.notas();
        }

        private bool ValidarDatosPersona(int edadMinima, int edadMaxima,
            out string nombre, out char sexo, out int edad)
        {
            nombre = textBox1.Text.Trim();
            sexo = '\0';
            edad = 0;

            if (nombre.Length == 0 || textBox2.Text.Trim().Length == 0)
            {
                MessageBox.Show("Indica el nombre y el sexo (H o M).");
                return false;
            }

            sexo = char.ToUpperInvariant(textBox2.Text.Trim()[0]);
            if (sexo != 'H' && sexo != 'M')
            {
                MessageBox.Show("El sexo debe ser H o M.");
                return false;
            }

            if (!int.TryParse(textBox3.Text, out edad) || edad < edadMinima || edad > edadMaxima)
            {
                MessageBox.Show($"La edad debe estar entre {edadMinima} y {edadMaxima} años.");
                return false;
            }

            return true;
        }
    }
}
