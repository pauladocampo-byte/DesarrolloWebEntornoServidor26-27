using BlogMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogMVC.Data;

/// <summary>Inserta publicaciones de ejemplo cuando la tabla todavía está vacía.</summary>
public static class BlogSeed
{
    // Callback de UseSeeding: EF Core lo invoca durante la inicialización de la base de datos.
    // El parámetro bool forma parte de la firma del callback; aquí no necesitamos su valor.
    // UseSeeding conviene cuando el alta requiere lógica/consultas o es condicional, como comprobar si hay filas.
    public static void Seed(DbContext context, bool _)
    {
        // Se consulta la tabla completa: si ya hay alguna publicación, no se agregan datos.
        var posts = context.Set<Post>();
        if (posts.Any()) return;

        // Crear las tres publicaciones de ejemplo y persistirlas en esta operación síncrona.
        // No asignamos PostId: SQL Server genera el valor identity al guardar y EF actualiza la entidad.
        posts.AddRange(CreatePosts());
        context.SaveChanges();
    }

    private static Post[] CreatePosts() =>
    [
        new Post
        {
            Titulo = "Primer artículo",
            Texto = "Este es el primer artículo del blog. Aquí contamos qué vamos a publicar y cómo se organiza el sitio.",
            FechaPublicacion = new DateTime(2026, 10, 1)
        },
        new Post
        {
            Titulo = "Cómo nace una idea",
            Texto = "Una publicación puede explicar un proyecto, compartir una experiencia o presentar una noticia.",
            FechaPublicacion = new DateTime(2026, 10, 5)
        },
        new Post
        {
            Titulo = "Archivo de marzo",
            Texto = "Este ejemplo antiguo nos servirá para probar la ruta del archivo por año y mes.",
            FechaPublicacion = new DateTime(2025, 3, 12)
        }
    ];
}
