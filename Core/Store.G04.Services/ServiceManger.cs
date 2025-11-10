using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Store.G04.Domain.Contracts;
using Store.G04.Domain.Entities.Identity;
using Store.G04.Services.Abstractions;
using Store.G04.Services.Abstractions.Auth;
using Store.G04.Services.Abstractions.Baskets;
using Store.G04.Services.Abstractions.Cache;
using Store.G04.Services.Abstractions.Products;
using Store.G04.Services.Auth;
using Store.G04.Services.Baskets;
using Store.G04.Services.Cache;
using Store.G04.Services.Products;
using Store.G04.Shared;

namespace Store.G04.Services
{
    public class ServiceManger(
        IUnitOfWork _unitOfWork,
        IMapper _mapper,
        IBasketRepository _basketRepository,
        ICacheRepository _cacheRepository,
        UserManager<AppUser> _userManager,
        IOptions<JwtOptions> _options
        ) : IServiceManger
    {
        public IProductService ProductService { get; } = new ProductService(_unitOfWork, _mapper);

        public IBasketService BasketService { get; } = new BasketService(_basketRepository, _mapper);

        public ICacheService CacheService { get; } = new CacheService(_cacheRepository);

        public IAuthService AuthService { get; } = new AuthService(_userManager, _options);
    }
}