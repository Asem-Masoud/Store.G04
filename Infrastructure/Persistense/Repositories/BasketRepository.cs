using StackExchange.Redis;
using Store.G04.Domain.Contracts;
using Store.G04.Domain.Entities.Baskets;
using System.Text.Json;

namespace Store.G04.Persistence.Repositories
{
    public class BasketRepository(IConnectionMultiplexer connection) : IBasketRepository
    {
        private readonly IDatabase _database = connection.GetDatabase();
        public async Task<CustomerBasket?> GetBasketAsync(string id)
        {
            // connection.GetDatabase();
            var redisValue = await _database.StringGetAsync(id);

            if (redisValue.IsNullOrEmpty) { return null; }

            var basket = JsonSerializer.Deserialize<CustomerBasket>(redisValue);

            if (basket is null) { return null; }

            return basket;
        }

        public async Task<CustomerBasket?> CreateBasketAsync(CustomerBasket basket, TimeSpan duration)
        {
            var redisValue = JsonSerializer.Serialize(basket);
            var flag = await _database.StringSetAsync(basket.Id, redisValue, duration);
            // _database.StringSet(basket.Id.ToString(), JsonSerializer.Serialize(basket), duration);
            if (!flag) { return null; }
            return await GetBasketAsync(basket.Id);
        }

        public async Task<bool> DeleteBasketAsync(string id)
        {
            return await _database.KeyDeleteAsync(id);
        }

    }
}