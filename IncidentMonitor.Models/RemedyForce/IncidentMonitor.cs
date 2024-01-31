using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentMonitor.Models.RemedyForce
{
    public class IncidentsMonitor
    {
        [Key]
        public int Id { get; set; }

        public DateTime? LastCheckedDate { get; set; }

        public string JsonData { get; set; }




    }
}
