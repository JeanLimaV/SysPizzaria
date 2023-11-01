using System.Collections.ObjectModel;
using AutoMapper;
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
        private readonly INotificator _notificator;

        public PurchaseService(IMapper mapper, IPurchasesRepository purchasesRepository, INotificator notificator)
        {
            _mapper = mapper;            
            _purchasesRepository = purchasesRepository;
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

        public async Task<PurchaseDTO?> CreateAsync(PurchaseDTO purchaseDto)
        {
            var purchaseExists = await _purchasesRepository.GetByIdAsync(purchaseDto.Id);
            if (purchaseExists != null)
                throw new AppDomainUnloadedException("Não existe nenhuma Compra registrada com esse Id!");
            
            purchaseDto.Date = DateTime.Now;
            var purchase = _mapper.Map<Purchase>(purchaseDto);
            if (!PurchaseValidate(purchase))
                return null;
                    
            await _purchasesRepository.CreateAsync(purchase);
            return purchaseDto;
        }

        public async Task<PurchaseDTO?> UpdateAsync(PurchaseDTO purchaseDto)
        {
            var purchaseExists = await _purchasesRepository.GetByIdAsync(purchaseDto.Id);
            if (purchaseExists == null)
                throw new AppDomainUnloadedException("Não existe nenhuma compra registrada com esse Id!");

            purchaseDto.Date = DateTime.Now;
            var purchase = _mapper.Map<Purchase>(purchaseDto);
            if (!PurchaseValidate(purchase))
                return null;
            
            await _purchasesRepository.UpdateAsync(purchase);
            return purchaseDto;
        }

        public async Task DeleteAsync(int id)
        {
            var purchaseExists = await _purchasesRepository.GetByIdAsync(id);
            if (purchaseExists == null)
                throw new AppDomainUnloadedException("Esta compra nunca existiu!");

            await _purchasesRepository.DeleteAsync(purchaseExists);
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
