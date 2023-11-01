using Microsoft.AspNetCore.Mvc;
using SysPizzaria.Application.DTOs;
using SysPizzaria.Application.Interfaces;

namespace SysPizzaria.API.Controllers
{
    [Route("API/[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        private readonly IPurchaseService _purchaseService;

        public PurchaseController(IPurchaseService purchaseService)
        {
            _purchaseService = purchaseService;
        }

        [HttpPost]
        [Route("/API/Purchase/Create")]
        public async Task<IActionResult> Create([FromBody] PurchaseDTO purchaseDto)
        {
            var purchase = await _purchaseService.CreateAsync(purchaseDto);
            return Ok(purchase);
        }

        [HttpPut]
        [Route("/API/Purchase/Update")]
        public async Task<IActionResult> Update([FromBody] PurchaseDTO purchaseDto)
        {
            var purchase = await _purchaseService.UpdateAsync(purchaseDto);
            return Ok(purchase);
        }

        [HttpDelete]
        [Route("/API/Purchase/Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            await _purchaseService.DeleteAsync(id);
            return Ok("Compra Deletada com Sucesso!");
        }

        [HttpGet]
        [Route("/API/Purchase/Get-Purchase")]
        public async Task<IActionResult> GetById(int id)
        {
            var purchase = await _purchaseService.GetByIdAsync(id);
            return Ok(purchase);
        }

        [HttpGet]
        [Route("/API/Purchase/Get-Purchases")]
        public async Task<IActionResult> GetPurchases()
        {
            var AllPurchases = await _purchaseService.GetPurchasesAsync();
            return Ok(AllPurchases);
        }
    }
}