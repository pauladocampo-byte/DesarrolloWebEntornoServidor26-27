using CatalogoTienda.Data;
using CatalogoTienda.Managers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("Tienda")
    ?? throw new InvalidOperationException("No se encontró la cadena de conexión 'Tienda'.");

builder.Services.AddDbContext<TiendaContext>(options =>
    options.UseSqlServer(connectionString));
        //.UseSeeding(CatalogoSeedData.Seed));

builder.Services.AddScoped<ProductoManager>();

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
    name: "infoProducto",
    pattern: "Productos/Info/{id:int}",
    defaults: new { controller = "Productos", action = "Info" });

app.MapControllerRoute(
    name: "filtrosProductos",
    pattern: "Productos/Filtros/{precioMaximo:decimal}/{stockMinimo:int}",
    defaults: new { controller = "Productos", action = "GetProductos" });

app.MapControllerRoute(
    name: "filtrosProductosQuery",
    pattern: "Productos/GetProductos",
    defaults: new { controller = "Productos", action = "GetProductos" });


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Productos}/{action=Index}/{id?}");

app.Run();
