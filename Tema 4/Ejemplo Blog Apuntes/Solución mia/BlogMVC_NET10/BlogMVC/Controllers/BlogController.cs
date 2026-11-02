using BlogMVC.Managers;
using Microsoft.AspNetCore.Mvc;

namespace BlogMVC.Controllers;

public class BlogController : Controller
{
    private readonly BlogManager _manager;

    public BlogController(BlogManager manager)
    {
        _manager = manager;
    }

    public IActionResult Index()
    {
        var posts = _manager.ListarUltimos();
        return View(posts);
    }

    public IActionResult Archive(int year, int month)
    {
        if (month is < 1 or > 12) return NotFound();

        var posts = _manager.BuscarPorMes(year, month);
        ViewBag.Periodo = $"{year}/{month}";
        return View(posts);
    }

    public IActionResult ViewPost(int codigo)
    {
        var post = _manager.BuscarPorId(codigo);
        if (post is null) return NotFound();

        return View(post);
    }
}
