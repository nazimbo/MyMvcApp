// File: Models/Product.cs

// Import the namespace for data annotations
using System.ComponentModel.DataAnnotations;

namespace MyMvcApp.Models
{
    // Define the Product class
    // This class represents the structure of a product in our application
    public class Product
    {
        // The Id property uniquely identifies each product
        // [Key] attribute specifies that this is the primary key in the database
        [Key]
        public int Id { get; set; }

        // The Name property stores the name of the product
        // [Required] means this field cannot be null or empty
        // [StringLength(100)] limits the name to 100 characters
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        // The Price property stores the price of the product
        // [Range(0.01, 9999.99)] ensures the price is between 0.01 and 9999.99
        [Range(0.01, 9999.99)]
        public decimal Price { get; set; }
    }
}