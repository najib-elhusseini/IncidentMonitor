using IncidentMonitor.DataLayer.Data;
using IncidentMonitor.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentMonitor.DataLayer.Helpers
{
    public abstract class EntityHelper<T, TKey> : IEntityHelper<T, TKey>
        where T : IDatabaseObject<TKey>, new()
        where TKey : IComparable
    {
        public EntityHelper(DataContext context)
        {
            Context = context;
        }

        public DataContext Context { get; protected set; }

        public SQLiteAsyncConnection Connection => Context.Connection;


        public virtual async Task<List<T>> GetAllAsync() => await Connection.Table<T>().ToListAsync();

        public virtual async Task<T> Find(TKey key)
        {
            var result = await Connection
                .Table<T>()
                .FirstOrDefaultAsync(item => item.Id != null && item.Id.Equals(key));

            return result;
        }

        public virtual async Task<int> InsertAsync(T item) => await Connection.InsertAsync(item);

        public virtual async Task<int> UpdateAsync(T item) => await Connection.UpdateAsync(item);

        public virtual async Task<int> DeleteAsync(T item) => await Connection.DeleteAsync(item);


    }
}
