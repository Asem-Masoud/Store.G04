using AutoMapper;
using Store.G04.Domain.Contracts;
using Store.G04.Domain.Entities.Baskets;
using Store.G04.Domain.Exceptions;
using Store.G04.Domain.Exceptions.BadRequest;
using Store.G04.Services.Abstractions.Baskets;
using Store.G04.Shared.Dtos.Baskets;

namespace Store.G04.Services.Baskets
{
    public class BasketService(IBasketRepository _basketRepository, IMapper _mapper) : IBasketService
    {
        public async Task<BasketDto?> GetBasketAsync(string id)
        {
            var basket = await _basketRepository.GetBasketAsync(id);
            if (basket is null) throw new BasketNotFoundException(id);
            var result = _mapper.Map<BasketDto>(basket);
            return result;
        }

        public async Task<BasketDto?> CreateBasketAsync(BasketDto dto, TimeSpan duration)
        {
            var basket = _mapper.Map<CustomerBasket>(dto);
            var result = await _basketRepository.CreateBasketAsync(basket, duration);
            // _basketRepository.CreateBasketAsync(_mapper.Map<CustomerBasket>(dto), duration);
            if (result is null) throw new CreateOrUpdateBasketBadRequestException();
            return _mapper.Map<BasketDto>(result);
        }

        public async Task<bool> DeleteBasketAsync(string id)
        {
            var flag = await _basketRepository.DeleteBasketAsync(id);
            if (!flag) throw new DeleteBasketBadRequestException();
            return flag;
        }
    }
}