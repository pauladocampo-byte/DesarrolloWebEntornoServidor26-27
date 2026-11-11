using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using MontecasteloAuthDemo.Data;
using MontecasteloAuthDemo.Services;
using MontecasteloAuthDemo.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Validate the effective configuration (including environment-variable overrides)
// before registering EF so this clone cannot target the source database.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if (string.IsNullOrWhiteSpace(connectionString))
{
    throw new InvalidOperationException("Connection string 'DefaultConnection' is missing or empty.");
}

var sqlConnectionString = new SqlConnectionStringBuilder(connectionString);
if (!string.Equals(sqlConnectionString.InitialCatalog, "MontecasteloAuthDemo_PasswordHasher_net10", StringComparison.OrdinalIgnoreCase))
{
    throw new InvalidOperationException(
        "Connection string 'DefaultConnection' must target database 'MontecasteloAuthDemo_PasswordHasher_net10'.");
}

// EF Core
builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseSqlServer(connectionString));

// MVC + Razor
builder.Services.AddControllersWithViews();

// Managers
builder.Services.AddScoped<IUsersManager, UsersManager>();
builder.Services.AddScoped<IAuthManager, AuthManager>();
builder.Services.AddScoped<IPasswordHasher<MontecasteloAuthDemo.Models.Usuario>, PasswordHasher<MontecasteloAuthDemo.Models.Usuario>>();

// Cookie Auth
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(opt =>
    {
        opt.LoginPath = "/Account/Login";
        opt.LogoutPath = "/Account/Logout";
        opt.AccessDeniedPath = "/Account/AccessDenied";
        opt.SlidingExpiration = true;
        opt.ExpireTimeSpan = TimeSpan.FromHours(8);
    });

builder.Services.AddAuthorization();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
