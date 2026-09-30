using System;

namespace Ejercicio19
{
    /// <summary>Persona con los datos y operaciones de salud pedidos en el ejercicio.</summary>
    public class Persona
    {
        private const char SEXO_POR_DEFECTO = 'H';
        public const int INFRAPESO = -1;
        public const int PESO_IDEAL = 0;
        public const int SOBREPESO = 1;
        private const string LETRAS_DNI = "TRWAGMYFPDXBNJZSQVHLCKE";
        private static readonly Random GeneradorAleatorio = new Random();

        private string nombre;
        private int edad;
        private readonly string dni;
        private char sexo;
        private double peso;
        private double altura;

        public Persona() : this("", 0, SEXO_POR_DEFECTO, 0, 0)
        {
        }

        public Persona(string nombre, int edad, char sexo) : this(nombre, edad, sexo, 0, 0)
        {
        }

        public Persona(string nombre, int edad, char sexo, double peso, double altura)
        {
            this.nombre = nombre ?? "";
            setEdad(edad);
            this.sexo = ComprobarSexo(sexo);
            setPeso(peso);
            setAltura(altura);
            dni = GenerarDni();
        }

        public void setNombre(string nombre)
        {
            this.nombre = nombre ?? "";
        }

        public void setEdad(int edad)
        {
            if (edad < 0) throw new ArgumentOutOfRangeException(nameof(edad));
            this.edad = edad;
        }

        public void setSexo(char sexo)
        {
            this.sexo = ComprobarSexo(sexo);
        }

        public void setPeso(double peso)
        {
            if (double.IsNaN(peso) || double.IsInfinity(peso) || peso < 0)
                throw new ArgumentOutOfRangeException(nameof(peso));
            this.peso = peso;
        }

        public void setAltura(double altura)
        {
            if (double.IsNaN(altura) || double.IsInfinity(altura) || altura < 0)
                throw new ArgumentOutOfRangeException(nameof(altura));
            this.altura = altura;
        }

        public int calcularIMC()
        {
            if (altura <= 0)
                throw new InvalidOperationException("La altura debe ser mayor que cero para calcular el IMC.");

            double imc = peso / (altura * altura);
            if (imc < 20) return INFRAPESO;
            if (imc <= 25) return PESO_IDEAL;
            return SOBREPESO;
        }

        public bool esMayorDeEdad() => edad >= 18;

        private static char ComprobarSexo(char sexo)
        {
            char sexoNormalizado = char.ToUpperInvariant(sexo);
            return sexoNormalizado == 'H' || sexoNormalizado == 'M' ? sexoNormalizado : SEXO_POR_DEFECTO;
        }

        private static string GenerarDni()
        {
            int numero = GeneradorAleatorio.Next(10_000_000, 100_000_000);
            return numero.ToString() + LETRAS_DNI[numero % 23];
        }

        public override string ToString()
        {
            string textoSexo = sexo == 'H' ? "hombre" : "mujer";
            return $"Nombre: {nombre}\nSexo: {textoSexo}\nEdad: {edad} años\nDNI: {dni}\nPeso: {peso} kg\nAltura: {altura} m";
        }
    }
}
