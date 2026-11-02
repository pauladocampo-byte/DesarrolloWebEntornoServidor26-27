using BlogMVC.Data;
using BlogMVC.Managers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var connection = builder.Configuration.GetConnectionString("ConexionMontecastelo")
    ?? throw new InvalidOperationException("No se encontró la cadena ConexionMontecastelo.");

builder.Services.AddDbContext<BlogContext>(options =>
    options.UseSqlServer(connection)
        // Registra el callback; no inserta datos durante esta configuración.
        // EF Core lo invoca en Update-Database, incluso si no hay migraciones nuevas, y necesita las tablas.
        // EF Core obtiene BlogContext desde la DI configurada en Program.cs en tiempo de diseño.
        .UseSeeding(BlogSeed.Seed));

builder.Services.AddScoped<BlogManager>();

var app = builder.Build();

if (!app.Environment.IsDevelopment()) app.UseHsts();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "blog-archive",
    pattern: "blog/archive/{year}/{month}",
    defaults: new { controller = "Blog", action = "Archive" });

app.MapControllerRoute(
    name: "blog-post",
    pattern: "blog/{codigo}",
    defaults: new { controller = "Blog", action = "ViewPost" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Blog}/{action=Index}/{id?}");

app.Run();
