using Microsoft.AspNetCore.Mvc;
using Store.G04.Services.Abstractions;
using Store.G04.Shared.Dtos.Baskets;
using System.Threading.Tasks;

namespace Store.G04.Presentation
{
    [ApiController]
    [Route("api/[controller]")]
    public class BasketsController(IServiceManger _serviceManger) : ControllerBase
    {
        [HttpGet] // GET: baseUrl/api/baskets?id
        public async Task<IActionResult> GetBasketById(string id)
        {
            var result = await _serviceManger.BasketService.GetBasketAsync(id);
            return Ok(result);
        }

        [HttpPost] // GET: baseUrl/api/baskets
        public async Task<IActionResult> CreateOrUpdateBasket(BasketDto dto)
        {
            var result = await _serviceManger.BasketService.CreateBasketAsync(dto, TimeSpan.FromDays(1));
            return Ok(result);
        }

        [HttpDelete] // GET: baseUrl/api/baskets?id
        public async Task<IActionResult> DeleteBasketById(string id)
        {
            var result = await _serviceManger.BasketService.DeleteBasketAsync(id);
            return NoContent(); // 204
        }

    }
}