using Microsoft.AspNetCore.Mvc;
using Store.G04.Services.Abstractions;

namespace Store.G04.Presentation
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController(IServiceManger _serviceManger) : ControllerBase
    {
        [HttpGet] // GET: baseUrl/api/products
        public async Task<IActionResult> GetAllProducts(int? brandId, int? typeId, string? sort, string? search)
        {
            var result = await _serviceManger.ProductService.GetAllProductsAsync(brandId, typeId, sort, search);
            if (result is null) return BadRequest(); //400
            return Ok(result); //200
        }

        [HttpGet("{id}")] // GET: baseUrl/api/products/5
        public async Task<IActionResult> GetProductById(int? id)
        {
            if (id is null) return BadRequest(); //400

            var result = await _serviceManger.ProductService.GetProductByIdAsync(id.Value);

            if (result is null) return NotFound(); //400

            return Ok(result); //200
        }

        [HttpGet("brands")] // GET: baseUrl/api/products/brands
        public async Task<IActionResult> GetAllBrands()
        {
            var result = await _serviceManger.ProductService.GetAllBrandsAsync();
            if (result is null) return NotFound(); //400
            return Ok(result); //200
        }

        [HttpGet("types")] // GET: baseUrl/api/products/types
        public async Task<IActionResult> GetAllTypes()
        {
            var result = await _serviceManger.ProductService.GetAllTypesAsync();
            if (result is null) return NotFound(); //400
            return Ok(result); //200
        }

    }
}