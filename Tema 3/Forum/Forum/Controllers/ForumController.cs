using Forum.Models;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Controllers
{
    public class ForumController : Controller
    {
        public IActionResult Browse(string forumName)
        {
            var msgs = ForumData.GetMessages(forumName);

            //asi pasamos el nombre del foro a la vista para que pueda mostrarlo en el título de la página
            ViewData["ForumName"] = forumName;
            ViewData["Title"] = forumName == "csharp" ? "C#" : forumName == "asp.net" ? "ASP.NET" : forumName;

            return View("Browse", msgs);

        }
    }
}
