using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio7
{
    class Cine
    {
        private static readonly Random GeneradorAleatorio = new Random();
        /*Atributos*/
        private Asiento[,] asientos;
        private double precio;
        private Pelicula pelicula;

        /*Constructor*/
        public Cine(int filas, int columnas, double precio, Pelicula pelicula)
        {
            if (filas <= 0) throw new ArgumentOutOfRangeException(nameof(filas));
            if (columnas <= 0 || columnas > 26) throw new ArgumentOutOfRangeException(nameof(columnas));
            if (precio < 0) throw new ArgumentOutOfRangeException(nameof(precio));
            if (pelicula == null) throw new ArgumentNullException(nameof(pelicula));

            asientos = new Asiento[filas, columnas];
            this.precio = precio;
            this.pelicula = pelicula;
            rellenaButacas();
        }

        /*Metodos*/
        public Asiento[,] getAsientos()
        {
            return asientos;
        }

        public void setAsientos(Asiento[,] asientos)
        {
            this.asientos = asientos;
        }

        public double getPrecio()
        {
            return precio;
        }

        public void setPrecio(double precio)
        {
            this.precio = precio;
        }

        public Pelicula getPelicula()
        {
            return pelicula;
        }

        public void setPelicula(Pelicula pelicula)
        {
            this.pelicula = pelicula;
        }

        /**
         * Rellena nuestros asientos, dandoles una fila y una letra
         */
        private void rellenaButacas()
        {

            int fila = asientos.GetLength(0);
            for (int i = 0; i < asientos.GetLength(0); i++)
            {
                for (int j = 0; j < asientos.GetLength(1); j++)
                {
                    //Recuerda que los char se pueden sumar
                    asientos[i, j] = new Asiento((char)('A' + j), fila);
                }
                fila--; //Decremento la fila para actualizar la fila
            }
        }

        /**
         * Indicamos si hay sitio en el cine, cuando vemos una vacia salimos de la
         * función
         *
         * @return
         */
        public bool haySitio()
        {

            for (int i = 0; i < asientos.GetLength(0); i++)
            {
                for (int j = 0; j < asientos.GetLength(1); j++)
                {
                    if (!asientos[i, j].ocupado())
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /**
         * Indico si en una posicion concreta esta ocupada
         *
         * @param fila
         * @param letra
         * @return
         */
        public bool haySitioButaca(int fila, char letra)
        {
            return !getAsiento(fila, letra).ocupado();
        }

        /**
         * Indicamos si el espectador cumple lo necesario para entrar: - Tiene
         * dinero - Tiene edad El tema de si hay sitio, se controla en el main
         *
         * @param e
         * @return
         */
        public bool sePuedeSentar(Espectador e)
        {
            return e.tieneDinero(precio) && e.tieneEdad(pelicula.getEdadMinima());
        }

        /**
         * Siento al espectador en un asiento
         *
         * @param fila
         * @param letra
         * @param e
         */
        public bool sentar(int fila, char letra, Espectador e)
        {
            if (e == null || !sePuedeSentar(e) || !haySitioButaca(fila, letra))
                return false;

            getAsiento(fila, letra).setEspectador(e);
            e.pagar(precio);
            return true;
        }

        public bool sentarAleatoriamente(Espectador espectador, out Asiento asientoAsignado)
        {
            asientoAsignado = null;
            if (espectador == null || !sePuedeSentar(espectador) || !haySitio())
                return false;

            List<Asiento> libres = new List<Asiento>();
            foreach (Asiento asiento in asientos)
            {
                if (!asiento.ocupado())
                    libres.Add(asiento);
            }

            asientoAsignado = libres[GeneradorAleatorio.Next(libres.Count)];
            asientoAsignado.setEspectador(espectador);
            espectador.pagar(precio);
            return true;
        }

        /**
         * Devuelvo un asiento concreto por su fila y letra
         *
         * @param fila
         * @param letra
         * @return
         */
        public Asiento getAsiento(int fila, char letra)
        {
            int indiceFila = asientos.GetLength(0) - fila;
            int indiceColumna = char.ToUpperInvariant(letra) - 'A';
            if (indiceFila < 0 || indiceFila >= asientos.GetLength(0)
                || indiceColumna < 0 || indiceColumna >= asientos.GetLength(1))
                throw new ArgumentOutOfRangeException(nameof(fila), "La fila o la letra de asiento no pertenece a esta sala.");

            return asientos[indiceFila, indiceColumna];
        }

        /**
         * Numero de filas de nuestro cine
         *
         * @return
         */
        public int getFilas()
        {
            return asientos.GetLength(0);
        }

        /**
         * Numero de columas de nuestro cine
         *
         * @return
         */
        public int getColumnas()
        {
            return asientos.GetLength(1);
        }

        /**
         * Mostramos la información de nuestro cine (Tambien se puede hacer en un
         * toString pero hay que devolver un String)
         */
        public void mostrar()
        {

            System.Text.StringBuilder informacion = new System.Text.StringBuilder();
            informacion.AppendLine("Información del cine");
            informacion.AppendLine("Película: " + pelicula);
            informacion.AppendLine("Precio de entrada: " + precio.ToString("C"));
            for (int i = 0; i < asientos.GetLength(0); i++)
            {
                for (int j = 0; j < asientos.GetLength(1); j++)
                {
                    informacion.AppendLine(asientos[i, j].toString());
                }
            }
            MessageBox.Show(informacion.ToString());
        }
    }
}
