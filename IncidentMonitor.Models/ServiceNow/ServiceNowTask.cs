using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
  <option value="-5" selected="SELECTED">Pending</option>
    <option value="1">Open</option>
    <option value="2">Work in Progress</option>
    <option value="3">Closed Complete</option>
    <option value="4">Closed Incomplete</option>
    <option value="7">Closed Skipped</option>
    <option value="10">On Hold</option>
 */

namespace IncidentMonitor.Models.ServiceNow
{
    public enum ServiceNowTaskStates
    {
        Pending = -5,
        Open = 1,
        WorkInProgress = 2,
        ClosedComplete=3,
        ColsedIncomplete=4,
        ClosedSkipped = 7,
        OnHold = 10,
    }

    public class ServiceNowTask
    {
     

    }
}
