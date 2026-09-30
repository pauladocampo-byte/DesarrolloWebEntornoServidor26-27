using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio6
{
    public class Aula
    {
        /*Atributos*/
        private int id;
        private Profesor profesor;
        private Alumno[] alumnos;
        private String asignatura;

        /*Constantes*/
        private const int MAX_ALUMNOS = 20;

        /*Constructores*/
        public Aula() : this(1, new Profesor(), CrearAlumnosAleatorios(),
            Constantes.ASIGNATURAS[MetodosSueltos.generaNumeroAleatorio(0, Constantes.ASIGNATURAS.Length - 1)])
        {
        }

        public Aula(int id, Profesor profesor, List<Alumno> alumnos, string asignatura)
        {
            if (id <= 0) throw new ArgumentOutOfRangeException(nameof(id));
            if (profesor == null) throw new ArgumentNullException(nameof(profesor));
            if (alumnos == null) throw new ArgumentNullException(nameof(alumnos));
            if (alumnos.Count == 0 || alumnos.Count > MAX_ALUMNOS)
                throw new ArgumentException($"El aula necesita entre 1 y {MAX_ALUMNOS} alumnos.", nameof(alumnos));
            if (!Constantes.ASIGNATURAS.Contains(asignatura))
                throw new ArgumentException("La asignatura del aula no es válida.", nameof(asignatura));

            this.id = id;
            this.profesor = profesor;
            this.alumnos = alumnos.ToArray();
            this.asignatura = asignatura;
        }

        private static List<Alumno> CrearAlumnosAleatorios()
        {
            List<Alumno> alumnos = new List<Alumno>();
            for (int i = 0; i < MAX_ALUMNOS; i++)
                alumnos.Add(new Alumno());
            return alumnos;
        }

        /*Metodos*/

        /**
         * Crea los alumnos para el aula
         */
        private void creaAlumnos()
        {

            for (int i = 0; i < alumnos.Length; i++)
            {
                alumnos[i] = new Alumno();
            }

        }


        /**
         * Indica si la asistencia de los alumnos es mayor del 50%
         * @return 
         */
        private bool asistenciaAlumnos()
        {

            int cuentaAsistencias = 0;

            //contamos las asistencias
            for (int i = 0; i < alumnos.Length; i++)
            {

                if (alumnos[i].isAsistencia())
                {
                    cuentaAsistencias++;
                }

            }

            MessageBox.Show($"Asisten {cuentaAsistencias} de {alumnos.Length} alumnos.");

            return cuentaAsistencias > alumnos.Length / 2.0;

        }

        /**
         * Indicamos si se puede dar clase
         * @return 
         */
        public bool darClase()
        {

            //Indicamos las condiciones para que se pueda dar la clase

            if (!profesor.isAsistencia())
            {
                MessageBox.Show("El profesor no esta, no se puede dar clase");
                return false;
            }
            else if (!string.Equals(profesor.getMateria(), asignatura, StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("La materia del profesor y del aula no es la misma, no se puede dar clase");
                return false;
            }
            else if (!asistenciaAlumnos())
            {
                MessageBox.Show("La asistencia no es suficiente, no se puede dar clase");
                return false;
            }

            MessageBox.Show("Se puede dar clase");
            return true;

        }

        /**
         * Indicamos las notas de los alumnos aprobados, chicos y chicas
         */
        public void notas()
        {

            int chicosApro = 0;
            int chicasApro = 0;

            for (int i = 0; i < alumnos.Length; i++)
            {

                //Comprobamos si el alumno esta aprobado
                if (alumnos[i].isAsistencia() && alumnos[i].getNota() >= 5)
                {
                    //Segun el sexo, aumentara uno o otro
                    if (alumnos[i].getSexo() == 'H')
                    {
                        chicosApro++;
                    }
                    else
                    {
                        chicasApro++;
                    }

                    MessageBox.Show(alumnos[i].toString());

                }

            }

            MessageBox.Show("Hay " + chicosApro + " chicos y " + chicasApro + " chicas aprobados/as");

        }

        public override string ToString()
        {
            return $"Aula {id} — {asignatura} — {alumnos.Length} alumnos — Profesor: {profesor.getNombre()} ({profesor.getMateria()})";
        }
    }
}
