public class Persona
{
    public string Nombre { get; private set; }
    public int Edad { get; private set; }

    public Persona(string nombre, int edad)
    {
        Nombre = nombre;
        Edad = edad;
    }

    public void CumplirAnos()
    {
        Edad++;
    }

    public string Presentarse()
    {
        return $"Hola, soy {Nombre} y tengo {Edad} años.";
    }
}
