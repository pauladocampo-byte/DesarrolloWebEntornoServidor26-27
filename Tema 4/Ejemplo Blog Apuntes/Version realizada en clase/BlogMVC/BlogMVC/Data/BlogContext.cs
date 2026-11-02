using BlogMVC.Models;
using Microsoft.EntityFrameworkCore;    

namespace BlogMVC.Data
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {
        }
        public DbSet<Post> Posts => Set<Post>();
    }
}
