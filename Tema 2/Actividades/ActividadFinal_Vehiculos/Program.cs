using ActividadFinalVehiculos.Interfaces;
using ActividadFinalVehiculos.Models;

List<Vehiculo> vehiculos = new List<Vehiculo>
{
    new Coche("Toyota", "Corolla", 5),
    new Moto("Yamaha", "MT-07", 689),
    new Coche("Seat", "León", 3)
};

foreach (Vehiculo vehiculo in vehiculos)
{
    // La llamada resuelve MostrarInfo según el tipo real del objeto (polimorfismo).
    vehiculo.MostrarInfo();

    // IReparable expresa una capacidad, independiente del tipo base Vehiculo.
    if (vehiculo is IReparable reparable)
    {
        reparable.Reparar();
    }

    Console.WriteLine(new string('-', 30));
}
