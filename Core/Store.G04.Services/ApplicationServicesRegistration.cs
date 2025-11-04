using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Store.G04.Services.Abstractions;
using Store.G04.Services.Mapping.Baskets;
using Store.G04.Services.Mapping.Products;

namespace Store.G04.Services
{
    public static class ApplicationServicesRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IServiceManger, ServiceManger>(); // Mapping
            services.AddAutoMapper(M => M.AddProfile(new ProductProfile(configuration)));
            services.AddAutoMapper(M => M.AddProfile(new BasketProfile()));

            return services;
        }
    }
}