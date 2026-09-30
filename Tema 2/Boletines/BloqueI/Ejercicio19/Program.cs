using System;
using System.Globalization;

namespace Ejercicio19
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.Write("Nombre: ");
            string nombre = Console.ReadLine() ?? "";
            int edad = LeerEntero("Edad: ");
            Console.Write("Sexo (H/M): ");
            string textoSexo = Console.ReadLine() ?? "";
            char sexo = textoSexo.Length > 0 ? textoSexo[0] : 'H';
            double peso = LeerDecimal("Peso en kg: ");
            double altura = LeerDecimal("Altura en metros (mayor que cero): ", estrictamentePositivo: true);

            Persona persona1 = new Persona(nombre, edad, sexo, peso, altura);
            Persona persona2 = new Persona(nombre, edad, sexo);
            persona2.setPeso(peso);
            persona2.setAltura(altura);
            Persona persona3 = new Persona();
            persona3.setNombre(nombre);
            persona3.setEdad(edad);
            persona3.setSexo(sexo);
            persona3.setPeso(peso);
            persona3.setAltura(altura);

            MostrarPersona("Persona 1 (constructor completo)", persona1);
            MostrarPersona("Persona 2 (constructor parcial)", persona2);
            MostrarPersona("Persona 3 (constructor por defecto y setters)", persona3);
        }

        private static int LeerEntero(string mensaje)
        {
            while (true)
            {
                Console.Write(mensaje);
                if (int.TryParse(Console.ReadLine(), out int valor) && valor >= 0)
                    return valor;
                Console.WriteLine("Introduce un número entero no negativo.");
            }
        }

        private static double LeerDecimal(string mensaje, bool estrictamentePositivo = false)
        {
            while (true)
            {
                Console.Write(mensaje);
                string texto = Console.ReadLine() ?? "";
                if (double.TryParse(texto, NumberStyles.Number, CultureInfo.CurrentCulture, out double valor)
                    && (estrictamentePositivo ? valor > 0 : valor >= 0))
                    return valor;
                Console.WriteLine("Introduce un número no negativo.");
            }
        }

        private static void MostrarPersona(string titulo, Persona persona)
        {
            Console.WriteLine($"\n=== {titulo} ===");
            double imc = persona.calcularIMC();
            if (imc == Persona.INFRAPESO)
                Console.WriteLine("Está por debajo de su peso ideal.");
            else if (imc == Persona.PESO_IDEAL)
                Console.WriteLine("Está en su peso ideal.");
            else
                Console.WriteLine("Tiene sobrepeso.");

            Console.WriteLine(persona.esMayorDeEdad()
                ? "Es mayor de edad."
                : "No es mayor de edad.");
            Console.WriteLine(persona);
        }
    }
}
