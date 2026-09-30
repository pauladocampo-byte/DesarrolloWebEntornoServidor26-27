using System;

namespace Ejercicio20
{
    class Program
    {
        static void Main(string[] args)
        {
            //Introducimos el tamaño del array y la longitud del password
            int tamanio = LeerPositivo("Introduce un tamaño para el array: ");
            int longitud = LeerPositivo("Introduce la longitud de los passwords: ");

            //Creamos los arrays
            Password[] listaPassword = new Password[tamanio];
            bool[] fortalezaPassword = new bool[tamanio];

            //Creamos objetos, indicamos si es fuerte y mostramos la contraseña y su fortaleza.
            for (int i = 0; i < listaPassword.Length; i++)
            {
                listaPassword[i] = new Password(longitud);
                fortalezaPassword[i] = listaPassword[i].esFuerte();
                Console.WriteLine(listaPassword[i].getContraseña() + " " + fortalezaPassword[i]);
            }
        }

        private static int LeerPositivo(string mensaje)
        {
            while (true)
            {
                Console.Write(mensaje);
                if (int.TryParse(Console.ReadLine(), out int valor) && valor > 0)
                    return valor;
                Console.WriteLine("Introduce un entero mayor que cero.");
            }
        }
    }
}
