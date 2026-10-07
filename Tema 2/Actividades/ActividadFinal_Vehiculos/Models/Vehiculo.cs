namespace ActividadFinalVehiculos.Models
{
    /// <summary>Datos y comportamiento comunes a los vehículos de la flota.</summary>
    public class Vehiculo
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }

        public Vehiculo(string marca, string modelo)
        {
            if (string.IsNullOrWhiteSpace(marca))
                throw new ArgumentException("La marca es obligatoria.", nameof(marca));

            if (string.IsNullOrWhiteSpace(modelo))
                throw new ArgumentException("El modelo es obligatorio.", nameof(modelo));

            Marca = marca;
            Modelo = modelo;
        }

        public virtual void MostrarInfo()
        {
            Console.WriteLine($"Marca: {Marca}");
            Console.WriteLine($"Modelo: {Modelo}");
        }
    }
}
