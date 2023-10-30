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
        public async Task<IActionResult> Create([FromBody] PurchaseDTO purchaseDto)
        {
            var purchase = await _purchaseService.CreateAsync(purchaseDto);
            return Ok(purchase);
        }
    }
}