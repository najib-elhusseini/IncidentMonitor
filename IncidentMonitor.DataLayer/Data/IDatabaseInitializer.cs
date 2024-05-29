using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentMonitor.DataLayer.Data
{
    public interface IDatabaseInitializer
    {
        public Task Initialize();
    }
}
