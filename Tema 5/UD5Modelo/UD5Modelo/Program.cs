using Microsoft.EntityFrameworkCore;
using UD5Modelo.Models;
using UD5Modelo.Models.Manager;
using UD5Modelo.Models.Manager.UD5Modelo.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IFutbolistaManager, FutbolistaManager>();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<Ud5Context>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("ConexionMontecastelo")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Futbolistas}/{action=Index}/{id?}");

app.Run();
