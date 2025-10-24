using Store.G04.Domain.Entities;
using System.Linq.Expressions;

namespace Store.G04.Domain.Contracts
{
    public interface ISpecifications<TKey, TEntity> where TEntity : BaseEntity<TKey>
    {
        List<Expression<Func<TEntity, object>>> Includes { get; set; }

        Expression<Func<TEntity, bool>>? Criteria { get; set; } // For Filtration

        public Expression<Func<TEntity, object>>? OrderBy { get; set; }
        public Expression<Func<TEntity, object>>? OrderByDescending { get; set; }
    }
}