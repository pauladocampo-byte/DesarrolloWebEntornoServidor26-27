using BlogMVC.Data;
using BlogMVC.Models;

namespace BlogMVC.Manager
{
    public class BlogManager
    {
        private readonly BlogContext _context;

        public BlogManager(BlogContext context)
        {
            _context = context;
        }

        public List<Post> ListarUltimos()
        {
            return _context.Posts
                .OrderByDescending(post=>post.FechaPublicacion)
                .Take(10)
                .ToList();
        }

        public  List<Post>BuscarPorMes(int year, int month)
        {
            return _context.Posts
                .Where(post => post.FechaPublicacion.Year == year && post.FechaPublicacion.Month == month)
                .OrderByDescending(post => post.FechaPublicacion)
                .ToList();
        }


        public Post? BuscarPorId(int id)
        {
            //return _context.Posts.Find(id);
            return _context.Posts.Where(post => post.PostId == id).FirstOrDefault();
            
            //return _context.Posts.FirstOrDefault(post => post.PostId == id);    
        }




    }
}
