using BlogMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogMVC.Data;

public class BlogContext : DbContext
{
    public BlogContext(DbContextOptions<BlogContext> options)
        : base(options)
    {
    }

    public DbSet<Post> Posts => Set<Post>();

    // OPCIÓN B (alternativa): HasData — desactivada.
    // OnModelCreating permite definir configuración y datos iniciales del modelo.
    // base.OnModelCreating conserva la configuración que aplica la clase base.
    // HasData administra estos registros mediante migraciones; no se llama aquí a SaveChanges.
    // Aunque PostId sea identity, HasData necesita identificadores explícitos y no nulos.
    // Elige HasData para pocos datos estables versionados con el modelo y las migraciones.
    // Para este seed condicional con lógica/consultas, UseSeeding es más apropiado.
    // Las fechas constantes hacen que el modelo sea determinista entre migraciones.
    // Es un ejemplo alternativo: no activar a la vez que UseSeeding para los mismos datos.
    // Any de UseSeeding no evita choques de IDs con publicaciones existentes.
    // Si se usa esta opción, probar con una BD independiente y generar una migración.
    /*
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Post>().HasData(
            new Post
            {
                PostId = 1,
                Titulo = "Primer artículo",
                Texto = "Este es el primer artículo del blog. Aquí contamos qué vamos a publicar y cómo se organiza el sitio.",
                FechaPublicacion = new DateTime(2026, 10, 1)
            },
            new Post
            {
                PostId = 2,
                Titulo = "Cómo nace una idea",
                Texto = "Una publicación puede explicar un proyecto, compartir una experiencia o presentar una noticia.",
                FechaPublicacion = new DateTime(2026, 10, 5)
            },
            new Post
            {
                PostId = 3,
                Titulo = "Archivo de marzo",
                Texto = "Este ejemplo antiguo nos servirá para probar la ruta del archivo por año y mes.",
                FechaPublicacion = new DateTime(2025, 3, 12)
            }
        );
    }
    */
}
