using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentMonitor.Models
{
    public interface IDatabaseObject<TKey> where TKey : IComparable
    {

        public TKey Id { get; set; }

    }
}
