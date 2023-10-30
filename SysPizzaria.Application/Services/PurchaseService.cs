using System.Collections.ObjectModel;
using AutoMapper;
using FluentValidation;
using SysPizzaria.Application.DTOs;
using SysPizzaria.Application.Interfaces;
using SysPizzaria.Domain.Contracts.Interfaces.Repositories;
using SysPizzaria.Domain.Entities;

namespace SysPizzaria.Application.Services
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IMapper _mapper;        
        private readonly IPurchasesRepository _purchasesRepository;
        private readonly IPeopleRepository _peopleRepository;
        private readonly IProductsRepository _productsRepository;
        private readonly INotificator _notificator;

        public PurchaseService(IMapper mapper, IPurchasesRepository purchasesRepository, IPeopleRepository peopleRepository, IProductsRepository productsRepository, INotificator notificator)
        {
            _mapper = mapper;            
            _purchasesRepository = purchasesRepository;
            _peopleRepository = peopleRepository;
            _productsRepository = productsRepository;
            _notificator = notificator;
        }

        public async Task<PurchaseDTO> GetByIdAsync(int id)
        {
            var purchase = await _purchasesRepository.GetByIdAsync(id);
            if (purchase == null)
                throw new AppDomainUnloadedException("Essa compra não existe");

            return _mapper.Map<PurchaseDTO>(purchase);
        }

        public async Task<Collection<PurchaseDTO>> GetPurchasesAsync()
        {
            var allPurchases = await _purchasesRepository.GetPurchasesAsync();

            return _mapper.Map<Collection<PurchaseDTO>>(allPurchases);
        }

        public async Task<PurchaseDTO> CreateAsync(PurchaseDTO purchaseDto)
        {
            if (!PurchaseValidate(_mapper.Map<Purchase>(purchaseDto)))
                return null;

            var productId = await _productsRepository.GetByCodErp(purchaseDto.CodErp);
            var personId = await _peopleRepository.GetByDocument(purchaseDto.Document);
            var purchase = new Purchase(productId, personId);
            
            var data = await _purchasesRepository.CreateAsync(purchase);
            purchaseDto.Id = data.Id;
            return _mapper.Map<PurchaseDTO>(purchaseDto);
        }

        public Task<PurchaseDTO> UpdateAsync(PurchaseDTO purchaseDto)
        {
            throw new NotImplementedException();
        }
        
        public Task DeleteAsync(PurchaseDTO purchaseDto)
        {
            throw new NotImplementedException();
        }
        
        private bool PurchaseValidate(Purchase purchase)
        {
            if (!purchase.Validate(out var validationResult))
            {
                _notificator.Handle(validationResult.Errors);
                return false;
            }

            return true;
        }
    }
}
