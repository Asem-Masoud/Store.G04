using Store.G04.Domain.Entities;

namespace Store.G04.Domain.Contracts
{
    public interface IGenaricRepository<TKey, TEntity> where TEntity : BaseEntity<TKey>
    {
        Task<IEnumerable<TEntity>> GetAllAsync(bool changeTracker = false);
        Task<IEnumerable<TEntity>> GetAllAsync(ISpecifications<TKey, TEntity> spec, bool changeTracker = false);
        Task<TEntity?> GetAsync(TKey key);
        Task<TEntity?> GetAsync(ISpecifications<TKey, TEntity> spec);
        Task AddAsync(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        Task<int> CountAsync(ISpecifications<TKey, TEntity> spec);
    }
}
