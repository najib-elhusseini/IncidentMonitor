using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentMonitor.Models.RemedyForce
{
    public abstract class RemedyForceStatusObject : RemedyForceObject
    {
        public string Name { get; set; }
    }

    public class Status : RemedyForceStatusObject
    {       
    }

    public class Impact : RemedyForceStatusObject { }

    public class Urgency : RemedyForceStatusObject { }

}
