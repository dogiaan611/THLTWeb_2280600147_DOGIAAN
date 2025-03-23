using Microsoft.EntityFrameworkCore;

namespace THLTWeb_2280600147_DOGIAAN.Models
{
    public class AnDbContext :DbContext
    {
        public AnDbContext(DbContextOptions<AnDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
    }
}
