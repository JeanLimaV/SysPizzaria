using SysPizzaria.Domain.Entities;

namespace SysPizzaria.Domain.Contracts.Interfaces.Repositories
{
    public interface IPurchasesRepository
    {
        Task<Purchase?> GetByIdAsync(int id);
        Task<ICollection<Purchase>> GetPurchasesAsync();
        Task<Purchase?> GetByPersonIdAsync(int personId);
        Task<Purchase?> GetByProductIdAsync(int productId);
        Task<Purchase> CreateAsync(Purchase purchase);
        Task UpdateAsync(Purchase purchase);
        Task DeleteAsync(Purchase purchase);
    }
}