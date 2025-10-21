using Store.G04.Domain.Contracts;
using Store.G04.Domain.Entities;
using Store.G04.Persistence.Data.Contexts;
using Store.G04.Persistence.Repositories;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.G04.Persistence
{
    public class UnitOfWork(StoreDbContext _context) : IUnitOfWork
    {
        private ConcurrentDictionary<string, object> _repositories = new ConcurrentDictionary<string, object>();

        public IGenaricRepository<TKey, TEntity> GetRepository<TKey, TEntity>() where TEntity : BaseEntity<TKey>
        {
            return (IGenaricRepository<TKey, TEntity>)_repositories.GetOrAdd(typeof(TEntity).Name, new GenericRepository<TKey, TEntity>(_context));
        }


        /*
        private Dictionary<string, object> _repositories = new Dictionary<string, object>();
        public IGenaricRepository<TKey, TEntity> GetRepository<TKey, TEntity>() where TEntity : BaseEntity<TKey>
        {
            var type = typeof(TEntity).Name;
            if (!_repositories.ContainsKey(type))
            {
                var repository = new GenericRepository<TKey, TEntity>(_context);
                _repositories.Add(type, repository);
            }
            return (IGenaricRepository<TKey, TEntity>)_repositories[type];
        }
        */

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
