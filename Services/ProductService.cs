// File: Services/ProductService.cs

using MyMvcApp.Models;
using MyMvcApp.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyMvcApp.Services
{
    // Interface defining the contract for ProductService
    // This allows for dependency injection and makes it easier to swap implementations or mock for testing
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task AddProductAsync(Product product);
        Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(int id);
    }

    // Implementation of IProductService
    public class ProductService : IProductService
    {
        // Private field to hold the product repository
        private readonly IProductRepository _productRepository;

        // Constructor that accepts a product repository
        // This allows the repository to be injected, promoting loose coupling
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // Retrieves all products
        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _productRepository.GetAllAsync();
        }

        // Retrieves a single product by its ID
        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _productRepository.GetByIdAsync(id);
        }

        // Adds a new product
        public async Task AddProductAsync(Product product)
        {
            await _productRepository.AddAsync(product);
        }

        // Updates an existing product
        public async Task UpdateProductAsync(Product product)
        {
            await _productRepository.UpdateAsync(product);
        }

        // Deletes a product by its ID
        public async Task DeleteProductAsync(int id)
        {
            await _productRepository.DeleteAsync(id);
        }
    }
}