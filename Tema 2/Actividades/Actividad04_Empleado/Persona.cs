public class Persona
{
    public string Nombre { get; private set; }
    public int Edad { get; private set; }

    public Persona(string nombre, int edad)
    {
        Nombre = nombre;
        Edad = edad;
    }
}
