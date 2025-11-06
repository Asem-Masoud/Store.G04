using Store.G04.Services.Abstractions.Auth;
using Store.G04.Services.Abstractions.Baskets;
using Store.G04.Services.Abstractions.Cache;
using Store.G04.Services.Abstractions.Products;

namespace Store.G04.Services.Abstractions
{
    public interface IServiceManger
    {
        IProductService ProductService { get; }
        IBasketService BasketService { get; }
        ICacheService CacheService { get; }
        IAuthService AuthService { get; }
    }
}