using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IncidentMonitor.DataLayer.Helpers
{
    public interface IEntityHelperEntity<T, TKey> where T : class
    {
        T? Get(TKey id, IEnumerable<string>? includedProperties = null);

        Task<T?> GetAsync(TKey id, IEnumerable<string>? includedProperties = null);

        IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, IEnumerable<string>? includedProperties = null);

        void Add(T entity);

        Task AddAsync(T entity);

        void Remove(TKey id);

        void Remove(T entity);

        void RemoveRange(IEnumerable<T> entities);


        void Update(T entity);
    }
}
