namespace BWAF_DAL.Repositories.Interfaces
{
    using BWAF_DAL.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public interface IRepository
    {
        Task<IEnumerable<TEntity>> GetAllAsync<TEntity>(
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string include = null)
            where TEntity : class, IEntity;

        Task<IEnumerable<TEntity>> GetAsync<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string include = null)
            where TEntity : class, IEntity;

        IQueryable<TEntity> GetQueryable<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string include = null,
            int? skip = null,
            int? take = null)
            where TEntity : class, IEntity;

        void Create<TEntity>(TEntity entity) where TEntity : class, IEntity;

        void CreateRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class, IEntity;

        void Update<TEntity>(TEntity entity) where TEntity : class, IEntity;

        void Delete<TEntity>(object id) where TEntity : class, IEntity;

        void Delete<TEntity>(TEntity entity) where TEntity : class, IEntity;

        Task SaveAsync();

        void CheckDatabase();
    }
}
