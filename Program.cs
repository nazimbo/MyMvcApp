// Import necessary namespaces
using Microsoft.EntityFrameworkCore;
using MyMvcApp.Data;
using MyMvcApp.Repositories;
using MyMvcApp.Services;

// Create a new WebApplicationBuilder, which is used to configure the application
var builder = WebApplication.CreateBuilder(args);

// Add services to the dependency injection container
// This adds support for controllers and views in the MVC pattern
builder.Services.AddControllersWithViews();

// Configure Entity Framework Core to use SQLite as the database
// The connection string specifies the database file name
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=MyMvcApp.db"));

// Register custom services and repositories for dependency injection
// AddScoped means a new instance is created for each HTTP request
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

// Build the application
var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    // In non-development environments, use a custom error page
    app.UseExceptionHandler("/Home/Error");
    // Enable HTTP Strict Transport Security (HSTS)
    app.UseHsts();
}

// Redirect HTTP requests to HTTPS
app.UseHttpsRedirection();

// Enable serving of static files (e.g., CSS, JavaScript, images)
app.UseStaticFiles();

// Enable routing
app.UseRouting();

// Enable authorization
app.UseAuthorization();

// Configure the default route for the application
// This sets up the pattern for how URLs map to controllers and actions
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Product}/{action=Index}/{id?}");

// Start the application
app.Run();