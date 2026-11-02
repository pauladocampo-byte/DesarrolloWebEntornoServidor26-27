using BlogMVC.Data;
using BlogMVC.Manager;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connection = builder.Configuration.GetConnectionString("ConexionMontecastelo")
    ?? throw new InvalidOperationException("No se encontró la cadena ConexionMontecastelo.");


builder.Services.AddDbContext<BlogContext>(options =>
    options.UseSqlServer(connection).UseSeeding(BlogSeed.Seed));

builder.Services.AddScoped<BlogManager>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();


app.MapControllerRoute(
    name: "blog-archive",
    pattern: "blog/archive/{year:int}/{month:int}",
    defaults: new { controller = "Blog", action = "Archive" }
    );

app.MapControllerRoute(
    name: "blog-post",
    pattern:"blog/{codigo:int}",
    defaults: new { controller = "Blog", action = "ViewPost" }
    );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Blog}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
