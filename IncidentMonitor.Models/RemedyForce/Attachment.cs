using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentMonitor.Models.RemedyForce
{
    public class Attachment : RemedyForceObject
    {
        public string? Name { get; set; }

        public string? Description { get; set; }

        public string? Body { get; set; }


    }
}
