using BlogMVC.Data;
using BlogMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogMVC.Managers;

public class BlogManager
{
    private readonly BlogContext _context;

    public BlogManager(BlogContext context)
    {
        _context = context;
    }

    public List<Post> ListarUltimos() =>
        _context.Posts
            .OrderByDescending(post => post.FechaPublicacion)
            .Take(10)
            .ToList();

    public List<Post> BuscarPorMes(int year, int month) =>
        _context.Posts
            .Where(post => post.FechaPublicacion.Year == year && post.FechaPublicacion.Month == month)
            .OrderByDescending(post => post.FechaPublicacion)
            .ToList();

    public Post? BuscarPorId(int codigo) =>
        _context.Posts.FirstOrDefault(post => post.PostId == codigo);
}
