namespace Store.G04.Services.Abstractions.Cache
{
    public interface ICacheService
    {
        Task SetAsync(string key, object value, TimeSpan duration);
        Task<string?> GetAsync(string key);
    }
}