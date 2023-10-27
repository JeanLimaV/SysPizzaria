using Microsoft.AspNetCore.Mvc;
using SysPizzaria.Application.DTOs;
using SysPizzaria.Application.Services.Interfaces;

namespace SysPizzaria.API.Controllers
{
    [Route("API/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        
        [HttpPost]
        [Route("/API/Product/Create")]
        public async Task<IActionResult> Create([FromBody] ProductDTO productDto)
        {
            var product = await _productService.CreateAsync(productDto);
            return Ok(product);
        }
        
        [HttpPut]
        [Route("/API/Product/Update")]
        public async Task<IActionResult> Update([FromBody] ProductDTO productDto)
        {
            var product = await _productService.UpdateAsync(productDto);
            return Ok(product);
        }

        [HttpDelete]
        [Route("/API/Product/Delete")]
        public async Task<IActionResult> Delete([FromBody] ProductDTO productDto)
        {
            await _productService.DeleteAsync(productDto);
            return NoContent();
        }

        [HttpGet]
        [Route("/API/Product/Get-Product")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetById(id);
            return Ok(product);
        }

        [HttpGet]
        [Route("/API/Product/Get-Products")]
        public async Task<IActionResult> GetProducts()
        {
            var allProducts = await _productService.GetProducts();
            return Ok(allProducts);
        }
    }
}