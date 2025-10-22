using Store.G04.Domain.Entities;

namespace Store.G04.Domain.Contracts
{
    public interface IUnitOfWork
    {
        // Generic Repositories

        IGenaricRepository<TKey, TEntity> GetRepository<TKey, TEntity>() where TEntity : BaseEntity<TKey>;

        // Save Changes
        Task<int> SaveChangesAsync();

    }
}
