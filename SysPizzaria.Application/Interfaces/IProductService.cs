using System.Collections.ObjectModel;
using SysPizzaria.Application.DTOs;

namespace SysPizzaria.Application.Services.Interfaces
{
    public interface IProductService
    {
        Task<ProductDTO> GetById(int id);
        Task<Collection<ProductDTO>> GetProducts();
        Task<ProductDTO> CreateAsync(ProductDTO productDto);
        Task<ProductDTO> UpdateAsync(ProductDTO productDto);
        Task DeleteAsync(ProductDTO productDto);
    }
}