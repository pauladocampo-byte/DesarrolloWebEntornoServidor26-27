public abstract class Figura : IFigura
{
    public string Color { get; private set; }

    public Figura(string color)
    {
        Color = color;
    }

    public abstract double CalcularArea();
    public abstract string ObtenerDescripcion();
}
