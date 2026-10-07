public class GestorFiguras
{
    private List<IFigura> figuras;

    public GestorFiguras()
    {
        figuras = new List<IFigura>();
    }

    public void Agregar(IFigura figura)
    {
        if (figura == null)
        {
            throw new ArgumentNullException(nameof(figura));
        }

        figuras.Add(figura);
    }

    public void MostrarTodas()
    {
        foreach (IFigura figura in figuras)
        {
            Console.WriteLine($"{figura.ObtenerDescripcion()} — Área: {figura.CalcularArea():F2}");
        }
    }
}
