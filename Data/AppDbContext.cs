// File: Data/AppDbContext.cs

// Import necessary namespaces
using Microsoft.EntityFrameworkCore;
using MyMvcApp.Models;

namespace MyMvcApp.Data
{
    // Define the AppDbContext class, inheriting from DbContext
    // DbContext is a fundamental class in Entity Framework Core that represents a session with the database
    public class AppDbContext : DbContext
    {
        // Constructor that accepts DbContextOptions
        // This allows the application to pass in configuration settings (like the database connection)
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // DbSet represents a collection of all entities of a given type that can be queried from the database
        // This property will allow us to query and save Product instances
        public DbSet<Product> Products { get; set; }

        // This method is called when the model for a derived context has been initialized
        // It can be used to further configure the model that was discovered by convention
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Call the base implementation first
            base.OnModelCreating(modelBuilder);

            // Additional model configuration can be added here
            // For example, you could use this to:
            // - Configure relationships between entities
            // - Set up indexes
            // - Configure complex types
            // - Set default values
            // - etc.
        }
    }
}