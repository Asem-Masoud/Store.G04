using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
using Store.G04.Domain.Contracts;
using Store.G04.Persistence.Data.Contexts;
using Store.G04.Persistence.Repositories;

namespace Store.G04.Persistence
{
    public static class InfrastructureServicesRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<StoreDbContext>(Options =>
            {
                Options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddScoped<IDbInitializer, DbInitialize>(); // Allow DI For DbInitializer
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IBasketRepository, BasketRepository>();
            services.AddScoped<ICacheRepository, CacheRepository>();

            services.AddSingleton<IConnectionMultiplexer>((ServiceProvider) =>
            ConnectionMultiplexer.Connect(configuration.GetConnectionString("RedisConnection"))
            );

            return services;
        }
    }
}
