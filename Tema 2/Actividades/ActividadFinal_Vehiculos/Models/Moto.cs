using ActividadFinalVehiculos.Interfaces;

namespace ActividadFinalVehiculos.Models
{
    /// <summary>Moto con cilindrada y capacidad de reparación.</summary>
    public class Moto : Vehiculo, IReparable
    {
        public int Cilindrada { get; set; }

        public Moto(string marca, string modelo, int cilindrada)
            : base(marca, modelo)
        {
            if (cilindrada <= 0)
                throw new ArgumentOutOfRangeException(nameof(cilindrada), "La cilindrada debe ser positiva.");

            Cilindrada = cilindrada;
        }

        public override void MostrarInfo()
        {
            Console.WriteLine("MOTO");
            base.MostrarInfo();
            Console.WriteLine($"Cilindrada: {Cilindrada} cc");
        }

        public void Reparar()
        {
            Console.WriteLine($"Reparando moto {Marca} {Modelo}...");
        }
    }
}
