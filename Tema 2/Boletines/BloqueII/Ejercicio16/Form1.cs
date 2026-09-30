using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Ejercicio16
{
    public sealed class Form1 : Form
    {
        private readonly TestAcademia test = new TestAcademia();
        private readonly Label lblPregunta = new Label();
        private readonly Label lblPuntuacion = new Label();
        private readonly FlowLayoutPanel panelOpciones = new FlowLayoutPanel();
        private readonly Button btnIniciar = new Button();
        private readonly Button btnComprobar = new Button();
        private readonly Button btnSiguiente = new Button();
        private bool respuestaComprobada;

        public Form1()
        {
            Text = "Test de la academia";
            StartPosition = FormStartPosition.CenterScreen;
            ClientSize = new Size(760, 500);
            MinimumSize = new Size(700, 450);

            btnIniciar.Text = "Iniciar / reiniciar test";
            btnIniciar.SetBounds(20, 20, 180, 35);
            btnIniciar.Click += BtnIniciar_Click;

            lblPuntuacion.Text = "Puntos: 0";
            lblPuntuacion.SetBounds(590, 28, 150, 25);

            lblPregunta.SetBounds(25, 80, 700, 100);
            lblPregunta.Font = new Font(Font, FontStyle.Bold);
            lblPregunta.AutoSize = false;

            panelOpciones.SetBounds(25, 190, 700, 190);
            panelOpciones.FlowDirection = FlowDirection.TopDown;
            panelOpciones.WrapContents = false;
            panelOpciones.AutoScroll = true;

            btnComprobar.Text = "Comprobar respuesta";
            btnComprobar.SetBounds(25, 415, 170, 35);
            btnComprobar.Enabled = false;
            btnComprobar.Click += BtnComprobar_Click;

            btnSiguiente.Text = "Siguiente pregunta";
            btnSiguiente.SetBounds(210, 415, 170, 35);
            btnSiguiente.Enabled = false;
            btnSiguiente.Click += BtnSiguiente_Click;

            Controls.AddRange(new Control[] { btnIniciar, lblPuntuacion, lblPregunta,
                panelOpciones, btnComprobar, btnSiguiente });
        }

        private void BtnIniciar_Click(object? sender, EventArgs e)
        {
            string fichero = Path.Combine(AppContext.BaseDirectory, "Preguntas.txt");
            try
            {
                test.CargarPreguntas(fichero);
                respuestaComprobada = false;
                btnComprobar.Enabled = false;
                btnSiguiente.Enabled = true;
                lblPuntuacion.Text = "Puntos: 0";
                MostrarSiguientePregunta();
            }
            catch (Exception ex) when (ex is IOException || ex is FormatException || ex is UnauthorizedAccessException)
            {
                MessageBox.Show("No se pudo cargar el test: " + ex.Message, Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnComprobar_Click(object? sender, EventArgs e)
        {
            if (respuestaComprobada) return;
            RadioButton? seleccion = null;
            foreach (Control control in panelOpciones.Controls)
            {
                if (control is RadioButton opcion && opcion.Checked)
                {
                    seleccion = opcion;
                    break;
                }
            }

            if (seleccion == null)
            {
                MessageBox.Show("Selecciona una opción.");
                return;
            }

            if (seleccion.Tag is not int respuesta)
            {
                MessageBox.Show("No se pudo identificar la opción seleccionada.");
                return;
            }

            bool correcta = test.ComprobarRespuesta(respuesta);
            respuestaComprobada = true;
            lblPuntuacion.Text = $"Puntos: {test.PuntosAcumulados}";
            MessageBox.Show(correcta ? "Respuesta correcta." : "Respuesta incorrecta.");
            btnComprobar.Enabled = false;
            btnSiguiente.Enabled = true;
        }

        private void BtnSiguiente_Click(object? sender, EventArgs e)
        {
            if (!respuestaComprobada && lblPregunta.Text.Length > 0)
            {
                MessageBox.Show("Comprueba la respuesta antes de continuar.");
                return;
            }

            respuestaComprobada = false;
            MostrarSiguientePregunta();
        }

        private void MostrarSiguientePregunta()
        {
            Pregunta? pregunta = test.SiguientePregunta();
            panelOpciones.Controls.Clear();
            if (pregunta == null)
            {
                lblPregunta.Text = $"Test terminado. Puntuación final: {test.PuntosAcumulados}";
                btnComprobar.Enabled = false;
                btnSiguiente.Enabled = false;
                return;
            }

            lblPregunta.Text = pregunta.Texto;
            for (int i = 0; i < pregunta.Opciones.Count; i++)
            {
                RadioButton opcion = new RadioButton
                {
                    Text = $"{i + 1}. {pregunta.Opciones[i].Texto}",
                    Tag = i + 1,
                    AutoSize = true,
                    Margin = new Padding(3, 8, 3, 8)
                };
                opcion.CheckedChanged += (sender, args) =>
                {
                    if (opcion.Checked && !respuestaComprobada) btnComprobar.Enabled = true;
                };
                panelOpciones.Controls.Add(opcion);
            }

            btnComprobar.Enabled = false;
            btnSiguiente.Enabled = false;
        }
    }
}
