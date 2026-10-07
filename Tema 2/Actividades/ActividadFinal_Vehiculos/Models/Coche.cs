using ActividadFinalVehiculos.Interfaces;

namespace ActividadFinalVehiculos.Models
{
    /// <summary>Vehículo con puertas y capacidad de reparación.</summary>
    public class Coche : Vehiculo, IReparable
    {
        public int Puertas { get; set; }

        public Coche(string marca, string modelo, int puertas)
            : base(marca, modelo)
        {
            if (puertas <= 0)
                throw new ArgumentOutOfRangeException(nameof(puertas), "El coche debe tener al menos una puerta.");

            Puertas = puertas;
        }

        public override void MostrarInfo()
        {
            Console.WriteLine("COCHE");
            base.MostrarInfo();
            Console.WriteLine($"Puertas: {Puertas}");
        }

        public void Reparar()
        {
            Console.WriteLine($"Reparando coche {Marca} {Modelo}...");
        }
    }
}
