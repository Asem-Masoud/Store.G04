using Store.G04.Shared.Dtos.Baskets;

namespace Store.G04.Services.Abstractions.Baskets
{
    public interface IBasketService
    {
        Task<BasketDto?> GetBasketAsync(string id);
        Task<BasketDto?> CreateBasketAsync(BasketDto dto, TimeSpan duration);
        Task<bool> DeleteBasketAsync(string id);
    }
}
