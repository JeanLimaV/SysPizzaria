using System.Collections.ObjectModel;
using SysPizzaria.Application.DTOs;

namespace SysPizzaria.Application.Interfaces
{
    public interface IPurchaseService 
    {
        Task<PurchaseDTO> GetByIdAsync(int id);
        Task<Collection<PurchaseDTO>> GetPurchasesAsync();
        Task<PurchaseDTO> CreateAsync(PurchaseDTO purchaseDto);
        Task<PurchaseDTO> UpdateAsync(PurchaseDTO purchaseDto);
        Task DeleteAsync(PurchaseDTO purchaseDto);
    }
}