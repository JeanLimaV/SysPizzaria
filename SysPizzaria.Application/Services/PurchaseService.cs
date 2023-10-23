using AutoMapper;
using FluentValidation;
using SysPizzaria.Application.DTOs;
using SysPizzaria.Application.Interfaces;
using SysPizzaria.Application.Notifications;
using SysPizzaria.Domain.Contracts.Interfaces.Repositories;
using SysPizzaria.Domain.Entities;

namespace SysPizzaria.Application.Services
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IMapper _mapper;
        private readonly IPurchasesRepository _purchasesRepository;
        private readonly IValidator<Purchase> _validator;
        private readonly INotificator _notificator;

        public PurchaseService(IMapper mapper, IPurchasesRepository purchasesRepository, INotificator notificator, IValidator<Purchase> validator)
        {
            _mapper = mapper;
            _purchasesRepository = purchasesRepository;
            _notificator = notificator;
            _validator = validator;
        }

        public async Task<PurchaseDTO> GetByIdAsync(int id)
        {
            var purchase = await _purchasesRepository.GetByIdAsync(id);
            if (purchase == null)
                throw new AppDomainUnloadedException("Essa compra não existe");

            return _mapper.Map<PurchaseDTO>(purchase);
        }

        public async Task<ICollection<PurchaseDTO>> GetPurchasesAsync()
        {
            var allPurchases = await _purchasesRepository.GetPurchasesAsync();

            return _mapper.Map<ICollection<PurchaseDTO>>(allPurchases);
        }

        public Task<PurchaseDTO> CreateAsync(PurchaseDTO purchaseDto)
        {
            throw new NotImplementedException();
        }

        public Task<PurchaseDTO> UpdateAsync(PurchaseDTO purchaseDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(PurchaseDTO purchaseDto)
        {
            throw new NotImplementedException();
        }
        
        private async Task<bool> PurchaseValidate(Purchase purchase)
        {
            var validationResult = await _validator.ValidateAsync(purchase);
            if (validationResult.IsValid) 
                return true;

            _notificator.Handle(validationResult.Errors);
            return false;
        }
    }
}
