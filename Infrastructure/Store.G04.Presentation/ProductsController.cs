using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.G04.Presentation.Attributes;
using Store.G04.Services.Abstractions;
using Store.G04.Shared;
using Store.G04.Shared.Dtos.Products;
using Store.G04.Shared.ErrorModels;

namespace Store.G04.Presentation
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController(IServiceManger _serviceManger) : ControllerBase
    {
        [HttpGet] // GET: baseUrl/api/products
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginationResponse<ProductResponse>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetails))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorDetails))]
        [Cache(30)]
        [Authorize]
        public async Task<ActionResult<PaginationResponse<ProductResponse>>> GetAllProducts([FromQuery] ProductQueryParameters parameters)
        {
            var result = await _serviceManger.ProductService.GetAllProductsAsync(parameters);
            // if (result is null) return BadRequest(); //400
            return Ok(result); //200
        }


        [HttpGet("{id}")] // GET: baseUrl/api/products/5
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetails))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorDetails))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDetails))]
        public async Task<ActionResult<ProductResponse>> GetProductById(int? id)
        {
            if (id is null) return BadRequest(); //400
            var result = await _serviceManger.ProductService.GetProductByIdAsync(id.Value);
            //if (result is null) return NotFound(); //400
            return Ok(result); //200
        }

        [HttpGet("brands")] // GET: baseUrl/api/products/brands
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<BrandTypeResponse>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetails))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorDetails))]
        public async Task<ActionResult<BrandTypeResponse>> GetAllBrands()
        {
            var result = await _serviceManger.ProductService.GetAllBrandsAsync();
            if (result is null) return NotFound(); //400
            return Ok(result); //200
        }

        [HttpGet("types")] // GET: baseUrl/api/products/types
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<BrandTypeResponse>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetails))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorDetails))]
        public async Task<ActionResult<BrandTypeResponse>> GetAllTypes()
        {
            var result = await _serviceManger.ProductService.GetAllTypesAsync();
            if (result is null) return NotFound(); //400
            return Ok(result); //200
        }

    }
}