using Microsoft.AspNetCore.Mvc;
using HuertoUrbano.Managers;
using HuertoUrbano.Models;

namespace HuertoUrbano.Controllers;

public class CultivosController(CultivoManager manager) : Controller
{
    public IActionResult Index() => View(manager.GetAll());

    public IActionResult Details(int id)
    {
        var x = manager.GetById(id);
        return x is null ? NotFound() : View(x);
    }

    public IActionResult Create() => View();

    [HttpPost, ValidateAntiForgeryToken]
    public IActionResult Create(Cultivo x)
    {
        if (!ModelState.IsValid)
        {
            return View(x);
        }

        manager.Create(x);
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Edit(int id)
    {
        var x = manager.GetById(id);
        return x is null ? NotFound() : View(x);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public IActionResult Edit(int id, Cultivo x)
    {
        if (id != x.Id)
        {
            return BadRequest();
        }

        if (!ModelState.IsValid)
        {
            return View(x);
        }

        if (manager.GetById(id) is null)
        {
            return NotFound();
        }

        manager.Update(x);
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Delete(int id)
    {
        var x = manager.GetById(id);
        return x is null ? NotFound() : View(x);
    }

    [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        var x = manager.GetById(id);
        if (x is null)
        {
            return NotFound();
        }

        manager.Delete(x);
        return RedirectToAction(nameof(Index));
    }
}
