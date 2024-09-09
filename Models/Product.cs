// File: Models/Product.cs
using System.ComponentModel.DataAnnotations;

namespace MyMvcApp.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Range(0.01, 9999.99)]
        public decimal Price { get; set; }
    }
}
