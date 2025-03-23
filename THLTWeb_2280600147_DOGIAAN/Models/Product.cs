using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace THLTWeb_2280600147_DOGIAAN.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required, StringLength(100)]
        public string? Name { get; set; }
        [Column(TypeName = "decimal(18,3)"), Range(0.01, 10000.00)]
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public List<ProductImage>? Images { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}