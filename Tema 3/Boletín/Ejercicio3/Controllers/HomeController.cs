using Ejercicio3.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ejercicio3.Controllers;

public class HomeController : Controller
{
    private static readonly IReadOnlyList<Futbolista> Plantilla =
    [
        new("Thibaut", "Courtois", 34, "Portero"),
        new("Andriy", "Lunin", 27, "Portero"),
        new("Dani", "Carvajal", 34, "Defensa"),
        new("Trent", "Alexander-Arnold", 27, "Defensa"),
        new("Éder", "Militão", 28, "Defensa"),
        new("Dean", "Huijsen", 21, "Defensa"),
        new("Antonio", "Rüdiger", 33, "Defensa"),
        new("David", "Alaba", 34, "Defensa"),
        new("Álvaro", "Carreras", 23, "Defensa"),
        new("Ferland", "Mendy", 31, "Defensa"),
        new("Fran", "García", 27, "Defensa"),
        new("Federico", "Valverde", 28, "Centrocampista"),
        new("Aurélien", "Tchouaméni", 26, "Centrocampista"),
        new("Eduardo", "Camavinga", 23, "Centrocampista"),
        new("Jude", "Bellingham", 23, "Centrocampista"),
        new("Arda", "Güler", 21, "Centrocampista"),
        new("Dani", "Ceballos", 30, "Centrocampista"),
        new("Vinícius", "Júnior", 26, "Delantero"),
        new("Kylian", "Mbappé", 27, "Delantero"),
        new("Rodrygo", "Goes", 25, "Delantero"),
        new("Brahim", "Díaz", 27, "Delantero"),
        new("Gonzalo", "García", 22, "Delantero"),
        new("Endrick", "Felipe", 20, "Delantero"),
        new("Franco", "Mastantuono", 19, "Delantero")
    ];

    public IActionResult Index()
    {
        return View(Plantilla);
    }
}
