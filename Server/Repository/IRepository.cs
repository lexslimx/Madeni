
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Madeni.Server.Repository
{
    public interface IRepository<TEntity, TDto> where TEntity : class
    {
        TDto AddItem(TEntity entity);

        TEntity GetItem(Expression<Func<TEntity, bool>> predicate);

        IEnumerable<TDto> GetItems(Expression<Func<TEntity, bool>> predicate);

        (IEnumerable<TEntity> items, int count) GetItems(Expression<Func<TEntity, bool>> predicate, int? skipSize, int? count);

        void Remove(Expression<Func<TEntity, bool>> predicate);

        TEntity AddItems(ICollection<TEntity> entities);
        //Add remove range
    }
}
