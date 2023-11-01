using SysPizzaria.Domain.Entities;

namespace SysPizzaria.Domain.Contracts.Interfaces.Repositories
{
    public interface IProductsRepository
    {
        Task<Product?> GetByCodErp(string codErp);
        Task<Product?> GetByIdAsync(int id);
        Task<ICollection<Product>> GetProductsAsync();
        Task<Product> CreateAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(Product product);
        
    }
}