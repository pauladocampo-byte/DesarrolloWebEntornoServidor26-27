namespace Ejercicio1.Models;

public sealed class BienvenidaViewModel
{
    public string? NombreDeUsuario { get; }

    public BienvenidaViewModel(string? nombreDeUsuario)
    {
        NombreDeUsuario = string.IsNullOrWhiteSpace(nombreDeUsuario)
            ? null
            : nombreDeUsuario;
    }
}
