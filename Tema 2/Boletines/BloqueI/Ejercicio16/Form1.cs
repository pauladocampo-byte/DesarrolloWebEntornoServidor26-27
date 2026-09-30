using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio16
{
    public partial class Form1 : Form
    {
        private readonly Dado miDado;
        private readonly Dado segundoDado;
        private readonly ComboBox cmbVersion;
        private readonly Button btnDosDados;

        public Form1()
        {
            InitializeComponent();
            miDado = new Dado();
            segundoDado = new Dado();
            Text = "Lanzamiento de dados";
            button1.SetBounds(330, 170, 140, 45);
            button1.Text = "Lanzar dado";

            cmbVersion = new ComboBox();
            cmbVersion.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbVersion.Items.AddRange(new object[]
            {
                "Versión 1: siempre obtiene 6",
                "Versión 2: incrementa el resultado anterior",
                "Versión 3: resultado aleatorio"
            });
            cmbVersion.SelectedIndex = 2;
            cmbVersion.SetBounds(170, 100, 460, 30);
            Controls.Add(cmbVersion);

            btnDosDados = new Button();
            btnDosDados.Text = "Lanzar dos dados";
            btnDosDados.SetBounds(330, 235, 140, 45);
            btnDosDados.Click += BtnDosDados_Click;
            Controls.Add(btnDosDados);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cmbVersion.SelectedIndex == 0)
                miDado.LanzarFijo();
            else if (cmbVersion.SelectedIndex == 1)
                miDado.LanzarIncremental();
            else
                miDado.LanzarAleatorio();

            MessageBox.Show("El valor del dado es: " + miDado.Valor);
        }

        private void BtnDosDados_Click(object sender, EventArgs e)
        {
            miDado.LanzarAleatorio();
            segundoDado.LanzarAleatorio();
            MessageBox.Show($"Dado 1: {miDado.Valor}; dado 2: {segundoDado.Valor}");
        }
    }
}
