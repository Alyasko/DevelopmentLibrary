using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BookPages.Contracts.Interfaces.Repositories
{
    public interface IRepository<TEntity>
    {
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(int id);

        IEnumerable<TEntity> GetAll();
    }
}
