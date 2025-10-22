using Microsoft.EntityFrameworkCore;
using Store.G04.Domain.Contracts;
using Store.G04.Domain.Entities;

namespace Store.G04.Persistence
{
    public static class SpecificationsEvaluator
    {
        // _context.Products.Include(P => P.Brand).Include(P => P.Type).Where(P => P.Id == key as int?).FirstOrDefaultAsync() as TEntity;
        // Generate Dynamic Query
        public static IQueryable<TEntity> GetQuery<TKey, TEntity>(IQueryable<TEntity> inputQuery, ISpecifications<TKey, TEntity> spec) where TEntity : BaseEntity<TKey>
        {
            var query = inputQuery; // _context.Products
            if (spec.Criteria is not null)
            {
                query = query.Where(spec.Criteria); // _context.Products.Where(P => P.Id == 12)
            }

            //  _context.Products.Where(P => P.Id == 12).Include(P => P.Brand)
            //  _context.Products.Where(P => P.Id == 12).Include(P => P.Brand).Include(P => P.Type)
            query = spec.Includes.Aggregate(query, (query, includeExpression) => query.Include(includeExpression));

            return query;
        }
    }
}