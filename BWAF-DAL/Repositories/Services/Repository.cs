namespace BWAF_DAL.Repositories.Services
{
    using BWAF_DAL.Models;
    using BWAF_DAL.Repositories.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public class Repository<TContext> : IRepository where TContext : DbContext
    {
        protected readonly TContext context;

        protected Repository(TContext context)
        {
            this.context = context;
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync<TEntity>(
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string include = null)
            where TEntity : class, IEntity
        {
            return await GetQueryable(null, orderBy, include, null, null).ToListAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAsync<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string include = null)
            where TEntity : class, IEntity
        {
            return await GetQueryable(filter, orderBy, include, null, null).ToListAsync();
        }

        public virtual IQueryable<TEntity> GetQueryable<TEntity>(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string include = null,
            int? skip = null,
            int? take = null)
            where TEntity : class, IEntity
        {
            include = include ?? string.Empty;
            IQueryable<TEntity> query = context.Set<TEntity>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var inc in include.Split(',', StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(inc);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }
            if (skip.HasValue)
            {
                query = query.Skip(skip.Value);
            }
            if (take.HasValue)
            {
                query = query.Take(take.Value);
            }

            return query;
        }

        public virtual void Create<TEntity>(TEntity entity) where TEntity : class, IEntity
        {
            context.Set<TEntity>().Add(entity);
        }

        public virtual void CreateRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class, IEntity
        {
            context.Set<TEntity>().AddRange(entities);
            context.ChangeTracker.DetectChanges();
        }

        public virtual void Update<TEntity>(TEntity entity) where TEntity : class, IEntity
        {
            context.Set<TEntity>().Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete<TEntity>(object id) where TEntity : class, IEntity
        {
            var entity = context.Set<TEntity>().Find(id);
            Delete(entity);
        }

        public virtual void Delete<TEntity>(TEntity entity) where TEntity : class, IEntity
        {
            var dbSet = context.Set<TEntity>();
            if (context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            dbSet.Remove(entity);
        }

        public async virtual Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }

        public virtual void CheckDatabase()
        {
            if (this.context.Database.EnsureCreated() == false)
            {
                return;
            }
        }
    }
}
