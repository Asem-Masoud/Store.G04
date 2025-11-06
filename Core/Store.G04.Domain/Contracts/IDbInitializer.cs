namespace Store.G04.Domain.Contracts
{
    public interface IDbInitializer
    {
        Task InitializeAsync();
        Task InitializeIdentityAsync();
    }
}