using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MontecasteloAuthDemo.Data;
using MontecasteloAuthDemo.Services;
using MontecasteloAuthDemo.Services.Interfaces;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseSqlServer(connectionString));

//Managers
builder.Services.AddScoped<IUsersManager, UsersManager>();
builder.Services.AddScoped<IAuthManager, AuthManager>();

builder.Services.AddScoped<IPasswordHasher<MontecasteloAuthDemo.Models.Usuario>, PasswordHasher<MontecasteloAuthDemo.Models.Usuario>>();


// Cookie Auth
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(opt =>
    {
        opt.LoginPath = "/Account/Login";
        //opt.LogoutPath = "/Account/Logout";
        //opt.AccessDeniedPath = "/Account/AccessDenied";
        opt.SlidingExpiration = true;
        opt.ExpireTimeSpan = TimeSpan.FromHours(8);
    });

// Add services to the container.
builder.Services.AddControllersWithViews();

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
    name: "default",
    pattern: "{controller=Users}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
