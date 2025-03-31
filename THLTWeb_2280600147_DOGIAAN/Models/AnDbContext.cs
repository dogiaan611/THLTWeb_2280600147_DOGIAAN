using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace THLTWeb_2280600147_DOGIAAN.Models
{
    public class AnDbContext : IdentityDbContext<ApplicationUser>
    {
        public AnDbContext(DbContextOptions<AnDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
    }
}
