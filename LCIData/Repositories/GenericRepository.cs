using LCIData.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using LCIEntities.Models;

namespace LCIData.Repositories
{

    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        protected LCIDataClassificationContext RepositoryContext { get; set; }


        protected RepositoryBase(LCIDataClassificationContext repositoryContext)
        {
            this.RepositoryContext = repositoryContext;

        }

        public IEnumerable<TEntity> FindAll()
        {
            return this.RepositoryContext.Set<TEntity>();
        }

        public IEnumerable<TEntity> FindByCondition(Expression<Func<TEntity, bool>> expression)
        {
            return this.RepositoryContext.Set<TEntity>().Where(expression);
        }

        public void Create(TEntity entity)
        {
            this.RepositoryContext.Set<TEntity>().Add(entity);
        }

        public void Update(TEntity entity)
        {
            this.RepositoryContext.Set<TEntity>().Update(entity);
        }

        public void Delete(TEntity entity)
        {
            this.RepositoryContext.Set<TEntity>().Remove(entity);
        }

    }
}
