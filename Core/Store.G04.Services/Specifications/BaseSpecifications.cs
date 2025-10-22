using Store.G04.Domain.Contracts;
using Store.G04.Domain.Entities;
using System.Linq.Expressions;

namespace Store.G04.Services.Specifications
{
    public class BaseSpecifications<TKey, TEntity> : ISpecifications<TKey, TEntity> where TEntity : BaseEntity<TKey>
    {
        public List<Expression<Func<TEntity, object>>> Includes { get; set; } = new List<Expression<Func<TEntity, object>>>();
        public Expression<Func<TEntity, bool>>? Criteria { get; set; }
        public BaseSpecifications(Expression<Func<TEntity, bool>>? expression) { Criteria = expression; }
    }
}