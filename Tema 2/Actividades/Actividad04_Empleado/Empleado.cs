using System.Globalization;

public class Empleado : Persona
{
    public string Puesto { get; private set; }
    public decimal Salario { get; private set; }

    public Empleado(string nombre, int edad, string puesto, decimal salario)
        : base(nombre, edad)
    {
        Puesto = puesto;
        Salario = salario;
    }

    public void MostrarInformacion()
    {

        Console.WriteLine($"Nombre: {Nombre}");
        Console.WriteLine($"Edad: {Edad}");
        Console.WriteLine($"Puesto: {Puesto}");
        Console.WriteLine($"Salario: {Salario:C}");
       //Console.WriteLine($"Salario: {Salario.ToString("C", CultureInfo.GetCultureInfo("es-ES"))}");

    }
}
