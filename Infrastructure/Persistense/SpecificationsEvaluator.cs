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

            // check if there is any Criteria to filter data
            if (spec.Criteria is not null)
            {
                query = query.Where(spec.Criteria); // _context.Products.Where(P => P.Id == 12)
            }

            // check if there is any OrderBy or OrderByDescending to sort data
            if (spec.OrderBy is not null)
            {
                query = query.OrderBy(spec.OrderBy); // _context.Products.Where(P => P.Id == 12).OrderBy(P => P.Name)
            }
            else if (spec.OrderByDescending is not null)
            {
                query = query.OrderByDescending(spec.OrderByDescending); // _context.Products.Where(P => P.Id == 12).OrderByDescending(P => P.Name)
            }

            if (spec.IsPagination)
            {
                query = query.Skip(spec.Skip).Take(spec.Take); // _context.Products.Where(P => P.Id == 12).OrderBy(P => P.Name).Skip(0).Take(5)
            }

            //  _context.Products.Where(P => P.Id == 12).Include(P => P.Brand)
            //  _context.Products.Where(P => P.Id == 12).Include(P => P.Brand).Include(P => P.Type)
            query = spec.Includes.Aggregate(query, (query, includeExpression) => query.Include(includeExpression));

            return query;
        }

    }
}