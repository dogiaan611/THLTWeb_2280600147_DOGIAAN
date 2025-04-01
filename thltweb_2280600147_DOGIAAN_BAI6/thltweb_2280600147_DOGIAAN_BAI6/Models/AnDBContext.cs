using Microsoft.EntityFrameworkCore;

namespace thltweb_2280600147_DOGIAAN_BAI6.Models
{
    public class AnDBContext : DbContext
    {
        public AnDBContext(DbContextOptions<AnDBContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");  // Chỉ định độ chính xác 18 chữ số, 2 số thập phân
        }
    }
}
