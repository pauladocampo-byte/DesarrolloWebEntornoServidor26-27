using Microsoft.AspNetCore.Mvc;
using CineClub.Managers;
using CineClub.Models;

namespace CineClub.Controllers;

public class PeliculasController(PeliculaManager manager) : Controller
{
    public IActionResult Index()
    {
        return View(manager.GetAll());
    }

    public IActionResult Details(int id)
    {
        var pelicula = manager.GetById(id);
        return pelicula is null ? NotFound() : View(pelicula);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost, ValidateAntiForgeryToken]
    public IActionResult Create(Pelicula pelicula)
    {
        if (!ModelState.IsValid)
        {
            return View(pelicula);
        }

        manager.Create(pelicula);
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Edit(int id)
    {
        var pelicula = manager.GetById(id);
        return pelicula is null ? NotFound() : View(pelicula);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public IActionResult Edit(int id, Pelicula pelicula)
    {
        if (id != pelicula.Id)
        {
            return BadRequest();
        }

        if (!ModelState.IsValid)
        {
            return View(pelicula);
        }

        if (manager.GetById(id) is null)
        {
            return NotFound();
        }

        manager.Update(pelicula);
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Delete(int id)
    {
        var pelicula = manager.GetById(id);
        return pelicula is null ? NotFound() : View(pelicula);
    }

    [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        var pelicula = manager.GetById(id);
        if (pelicula is null)
        {
            return NotFound();
        }

        manager.Delete(pelicula);
        return RedirectToAction(nameof(Index));
    }
}
