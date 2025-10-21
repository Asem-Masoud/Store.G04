using Store.G04.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
