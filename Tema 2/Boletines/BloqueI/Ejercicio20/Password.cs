using System;
using System.Text;

namespace Ejercicio20
{
    public class Password
    {
        private const int LONGITUD_POR_DEFECTO = 8;
        private const string CARACTERES = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        private static readonly Random generadorAleatorio = new Random();

        private int longitud;
        private string contraseña;

        public Password() : this(LONGITUD_POR_DEFECTO)
        {
        }

        public Password(int longitud)
        {
            if (longitud <= 0)
                throw new ArgumentOutOfRangeException(nameof(longitud), "La longitud debe ser positiva.");

            this.longitud = longitud;
            contraseña = generaPassword();
        }

        public int getLongitud() => longitud;

        public void setLongitud(int longitud)
        {
            if (longitud <= 0)
                throw new ArgumentOutOfRangeException(nameof(longitud), "La longitud debe ser positiva.");

            this.longitud = longitud;
            contraseña = generaPassword();
        }

        public string getContraseña() => contraseña;

        public string generaPassword()
        {
            StringBuilder resultado = new StringBuilder(longitud);
            for (int i = 0; i < longitud; i++)
            {
                int indice = generadorAleatorio.Next(CARACTERES.Length);
                resultado.Append(CARACTERES[indice]);
            }

            contraseña = resultado.ToString();
            return contraseña;
        }

        public bool esFuerte()
        {
            int numeros = 0;
            int minusculas = 0;
            int mayusculas = 0;

            foreach (char caracter in contraseña)
            {
                if (caracter >= '0' && caracter <= '9')
                    numeros++;
                else if (caracter >= 'a' && caracter <= 'z')
                    minusculas++;
                else if (caracter >= 'A' && caracter <= 'Z')
                    mayusculas++;
            }

            return numeros > 5 && minusculas > 1 && mayusculas > 2;
        }
    }
}
