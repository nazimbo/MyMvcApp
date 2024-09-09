// File: Controllers/ProductController.cs

// Import necessary namespaces
using Microsoft.AspNetCore.Mvc;
using MyMvcApp.Services;
using MyMvcApp.Models;
using System.Threading.Tasks;

namespace MyMvcApp.Controllers
{
    // Define the ProductController class, inheriting from Controller
    public class ProductController : Controller
    {
        // Private readonly field to store the IProductService
        private readonly IProductService _productService;

        // Constructor that uses dependency injection to get an IProductService
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: /Product/
        // Action method to display a list of all products
        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAllProductsAsync();
            return View(products);
        }

        // GET: /Product/Create
        // Action method to display the create product form
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Product/Create
        // Action method to handle the submission of the create product form
        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                await _productService.AddProductAsync(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: /Product/Edit/5
        // Action method to display the edit product form
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: /Product/Edit/5
        // Action method to handle the submission of the edit product form
        [HttpPost]
        public async Task<IActionResult> Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                await _productService.UpdateProductAsync(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: /Product/Delete/5
        // Action method to display the delete product confirmation page
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: /Product/Delete/5
        // Action method to handle the confirmed deletion of a product
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _productService.DeleteProductAsync(id);
            return RedirectToAction("Index");
        }
    }
}