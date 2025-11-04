namespace Store.G04.Domain.Contracts
{
    public interface IChacheRepository
    {
        Task<string?> GetAsync(string key);
        Task SetAsync(string key, object value, TimeSpan duration);
    }
}
