using IncidentMonitor.DataLayer.Data;
using IncidentMonitor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentMonitor.DataLayer.Helpers
{
    public interface IEntityHelper<T, TKey>
        where T : IDatabaseObject<TKey>, new()
        where TKey : IComparable
    {
        public DataContext Context { get; }

    }
}
