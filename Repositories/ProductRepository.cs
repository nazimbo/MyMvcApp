// File: Repositories/ProductRepository.cs

using MyMvcApp.Models;
using MyMvcApp.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyMvcApp.Repositories
{
    // Interface defining the contract for ProductRepository
    // This allows for dependency injection and makes it easier to swap implementations or mock for testing
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);
        Task AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(int id);
    }

    // Implementation of IProductRepository
    public class ProductRepository : IProductRepository
    {
        // Private field to hold the database context
        private readonly AppDbContext _context;

        // Constructor that accepts a database context
        // This allows the context to be injected, promoting loose coupling
        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        // Retrieves all products from the database
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        // Retrieves a single product by its ID
        public async Task<Product> GetByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        // Adds a new product to the database
        public async Task AddAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        // Updates an existing product in the database
        public async Task UpdateAsync(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }

        // Deletes a product from the database by its ID
        public async Task DeleteAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }
    }
}