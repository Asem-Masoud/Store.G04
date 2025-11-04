using AutoMapper;
using Store.G04.Domain.Entities.Baskets;
using Store.G04.Shared.Dtos.Baskets;

namespace Store.G04.Services.Mapping.Baskets
{
    public class BasketProfile : Profile
    {
        public BasketProfile()
        {
            CreateMap<CustomerBasket, BasketDto>().ReverseMap();

            CreateMap<BasketItem, BasketItemDto>().ReverseMap();
        }
    }
}