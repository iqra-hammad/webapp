using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using webapp.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(); // Adds services for controllers with views
builder.Services.AddDbContext<SurveyWebAppContext>(options =>
{
    // Configures Entity Framework to use SQL Server with a connection string from appsettings.json
    options.UseSqlServer(builder.Configuration.GetConnectionString("SurveyWebAppConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // Use a custom error page if not in development mode
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles(); // Enables serving static files (like CSS, JS, images)

app.UseRouting(); // Enables routing capabilities

app.UseAuthorization(); // Enables authorization middleware

// Define the default route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run(); // Runs the application