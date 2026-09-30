using System;

namespace Ejercicio12
{
    class Program
    {
        static void Main(string[] args)
        {
            Vehiculo micoche = new Vehiculo();
            micoche.Tipo = "Coche";
            micoche.Fabricante = "Ford";
            micoche.N_Ruedas = 4;
            micoche.Pasajeros = 5;
            Vehiculo.Consumo = 6.5;
            Vehiculo.PrecioGasolina = 1.60;
            Console.WriteLine($"{micoche.Tipo} {micoche.Fabricante}, {micoche.N_Ruedas} ruedas, {micoche.Pasajeros} pasajeros");
            Console.WriteLine($"Coste estimado por km: {Vehiculo.PrecioPorKm():C}");
        }
    }
}
