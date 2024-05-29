using IncidentMonitor.DataLayer.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IncidentMonitor.DataLayer.Helpers
{
    public abstract class EntityHelperEntity<T, TKey> : IEntityHelperEntity<T, TKey> where T : class
    {
        private DbSet<T> _dbSet;


        #region Ctor
        public EntityHelperEntity(ApplicationDbContext context)
        {
            Context = context;
            _dbSet = context.Set<T>();
        }

        #endregion

        #region Props
        public ApplicationDbContext Context { get; set; }

        protected DbSet<T> DBSet => _dbSet;
        #endregion


        public virtual T? Get(TKey id, IEnumerable<string>? includedProperties = null)
        {
            if (includedProperties != null)
            {
                foreach (var prop in includedProperties)
                {
                    _dbSet.Include(prop);
                }
                //throw new NotImplementedException();
            }
            return _dbSet.Find(id);
        }

        public virtual async Task<T?> GetAsync(TKey id, IEnumerable<string>? includedProperties = null)
        {
            if (includedProperties != null)
            {
                throw new NotImplementedException();
            }
            return await _dbSet.FindAsync(id);
        }

        public virtual IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, IEnumerable<string>? includedProperties = null)
        {
            IQueryable<T> query = _dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (includedProperties != null && includedProperties.Any())
            {
                foreach (var prop in includedProperties)
                {
                    query.Include(prop);
                }
            }

            return query.ToList();
        }

        public virtual void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public virtual async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public virtual void Remove(TKey id)
        {
            var entity = Get(id);
            Remove(entity);
        }

        public virtual void Remove(T? entity)
        {
            if (entity == null)
            {
                return;
            }
            _dbSet.Remove(entity);
        }

        public virtual void RemoveRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public virtual void Update(T entity)
        {
            throw new NotImplementedException();
        }



    }
}
