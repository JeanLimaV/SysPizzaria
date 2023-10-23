using SysPizzaria.Domain.Entities;

namespace SysPizzaria.Domain.Contracts.Interfaces.Repositories
{
    public interface IPurchasesRepository
    {
        Task<Purchase> GetByIdAsync(int id);
        Task<ICollection<Purchase>> GetPurchasesAsync();
        Task<ICollection<Purchase>> GetByPersonIdAsync(int productId);
        Task<ICollection<Purchase>> GetByProductIdAsync(int personId);
        Task<Purchase> CreateAsync(Purchase purchase);
        Task UpdateAsync(Purchase purchase);
        Task DeleteAsync(Purchase purchase);
    }
}