using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentMonitor.Models
{
    public enum EventAcknowledgedStatus //EventAcknowledgedStatus
    {
        Unknown = 0,
        UnrespondedInShift,
        RespondedInShift,
        UnsrespondedNotInShift,
        RespondedNotInShift,
        CallbackNotRequired,
    }
}
