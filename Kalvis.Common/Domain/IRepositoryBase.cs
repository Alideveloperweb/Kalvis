
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Kalvis.Common.Domain
{
    public interface IRepositoryBase<Tkey,TEntity>where TEntity : class
    {
        TEntity Get(Tkey Id);
        List<TEntity> GetAll();
        bool Create(TEntity entity);
        bool CreateRange(List<TEntity> entity);
        bool Update(TEntity entity);
        bool Remove(TEntity entity);
        bool RemoveRange(List<TEntity> entity);
        bool Exist(Expression<Func<TEntity, bool>> expression);
        bool SaveChanges();
    }
}
