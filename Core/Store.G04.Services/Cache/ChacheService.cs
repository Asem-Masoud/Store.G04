using Store.G04.Domain.Contracts;
using Store.G04.Services.Abstractions.Cache;

namespace Store.G04.Services.Cache
{
    public class CacheService(ICacheRepository _cacheRepository) : ICacheService
    {

        public async Task<string?> GetAsync(string key)
        {
            var result = await _cacheRepository.GetAsync(key);
            return result;
        }

        public async Task SetAsync(string key, object value, TimeSpan duration)
        {
            await _cacheRepository.SetAsync(key, value, duration);
        }
    }
}