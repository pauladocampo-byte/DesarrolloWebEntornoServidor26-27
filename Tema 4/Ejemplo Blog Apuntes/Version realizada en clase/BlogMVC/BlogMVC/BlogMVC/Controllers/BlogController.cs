using BlogMVC.Manager;
using Microsoft.AspNetCore.Mvc;

namespace BlogMVC.Controllers
{
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
            var posts = _manager.BuscarPorMes(year, month);
            ViewBag.Periodo = $"{year}/{month}";
            return View(posts);
        }

        public IActionResult ViewPost(int codigo)
        {
            var post = _manager.BuscarPorId(codigo);
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }

    }
}
