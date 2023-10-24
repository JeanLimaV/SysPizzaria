using AutoMapper;
using FluentValidation;
using SysPizzaria.Application.DTOs;
using SysPizzaria.Application.Interfaces;
using SysPizzaria.Application.Services.Interfaces;
 using SysPizzaria.Domain.Contracts.Interfaces.Repositories;
using SysPizzaria.Domain.Entities;

namespace SysPizzaria.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IProductsRepository _productsRepository;
        private readonly INotificator _notificator;

        public ProductService(IMapper mapper, IProductsRepository productsRepository, INotificator notificator)
        {
            _mapper = mapper;
            _productsRepository = productsRepository;
            _notificator = notificator;
        }

        public async Task<ProductDTO> GetById(int id)
        {
            var product = await _productsRepository.GetByIdAsync(id);
            if (product == null)
                throw new AppDomainUnloadedException("Não existe nenhum produto com esse Id!");

            return _mapper.Map<ProductDTO>(product);
        }

        public async Task<ICollection<ProductDTO>> GetProducts()
        {
            var allProducts = await _productsRepository.GetProductsAsync();

            return _mapper.Map<ICollection<ProductDTO>>(allProducts);
        }

        public async Task<ProductDTO> CreateAsync(ProductDTO productDto)
        {
            var productExists = await _productsRepository.GetByCodErp(productDto.CodERP);

            if (productExists != null)
                throw new AppDomainUnloadedException("Esse Produto já está cadastrado!");

            var product = _mapper.Map<Product>(productDto);
            if (!ProductValidate(product))
                return null;

            await _productsRepository.CreateAsync(product);
            return productDto;
        }

        public async Task<ProductDTO> UpdateAsync(ProductDTO productDto)
        {
            var productExists = await _productsRepository.GetByIdAsync(productDto.Id);

            if (productExists == null)
                throw new AppDomainUnloadedException("Não existe nenhum produto com esse Id cadastrado!");

            var product = _mapper.Map<Product>(productDto);
            if (!ProductValidate(product))
                return null;

            await _productsRepository.UpdateAsync(product);
            return productDto;
        }

        public async Task DeleteAsync(ProductDTO productDto)
        {
            var productExists = await _productsRepository.GetByIdAsync(productDto.Id);

            if (productExists == null)
                throw new AppDomainUnloadedException("Não existe nenhum produto com esse Id cadastrado!");

            var product = _mapper.Map<Product>(productDto);
            await _productsRepository.DeleteAsync(product);
        }
        
        private bool ProductValidate(Product product)
        {
            if (!product.Validate(out var validationResult))
            {
                _notificator.Handle(validationResult.Errors);
                return false;
            }

            return true;
        }
    }
}
