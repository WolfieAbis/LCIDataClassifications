using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace LCIData.Interface
{
    public interface IRepositoryBase<TEntity>
    {
        List<TEntity> FindAll();
        IEnumerable<TEntity> FindByCondition(Expression<Func<TEntity, bool>> expression);
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);

    }
}
