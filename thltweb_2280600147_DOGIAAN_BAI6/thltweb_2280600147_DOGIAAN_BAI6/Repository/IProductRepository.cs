using thltweb_2280600147_DOGIAAN_BAI6.Models;

namespace thltweb_2280600147_DOGIAAN_BAI6.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task AddProductAsync(Product product);
        Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(int id);
    }
}
