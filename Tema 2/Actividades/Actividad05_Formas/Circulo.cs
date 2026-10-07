public class Circulo : Figura
{
    public double Radio { get; private set; }

    public Circulo(string color, double radio)
        : base(color)
    {
        if (radio <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(radio), "El radio debe ser positivo.");
        }

        Radio = radio;
    }

    public override double CalcularArea()
    {
        return Math.PI * Radio * Radio;
    }

    public override string ObtenerDescripcion()
    {
        return $"Círculo ({Color})";
    }
}
