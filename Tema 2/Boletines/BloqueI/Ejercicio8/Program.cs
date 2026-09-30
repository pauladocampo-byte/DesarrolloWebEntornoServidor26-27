using System;

namespace Ejercicio8
{
    class Program
    {
        static void Main(string[] args)
        {
            Globo globo = new Globo(50, 50, 20, "azul");
            Console.WriteLine($"Globo de color {globo.Color}, diámetro {globo.Diametro}.");
        }
    }
}
