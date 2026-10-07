var builder = WebApplication.CreateBuilder(args);

// MVC reúne el enrutamiento a controladores y la generación de vistas Razor.
builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// Ruta específica para las URL del foro: action y nombre del foro.
app.MapControllerRoute(
    name: "forum",
    pattern: "forum/{action}/{forumName}",
    defaults: new { controller = "Forum" });

// Ruta de administración del ejemplo de clase. Se declara antes de la general.
app.MapControllerRoute(
    name: "admin",
    pattern: "admin/{controller}/{action}/{id?}");

// Ruta convencional para la portada y el resto de controladores.
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
