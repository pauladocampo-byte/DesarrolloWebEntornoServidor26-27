public class Rectangulo : Figura
{
    public double Ancho { get; private set; }
    public double Alto { get; private set; }

    public Rectangulo(string color, double ancho, double alto)
        : base(color)
    {
        if (ancho <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(ancho), "El ancho debe ser positivo.");
        }

        if (alto <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(alto), "El alto debe ser positivo.");
        }

        Ancho = ancho;
        Alto = alto;
    }

    public override double CalcularArea()
    {
        return Ancho * Alto;
    }

    public override string ObtenerDescripcion()
    {
        return $"Rectángulo ({Color})";
    }
}
