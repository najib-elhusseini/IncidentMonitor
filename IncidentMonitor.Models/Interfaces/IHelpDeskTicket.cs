using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentMonitor.Models
{
    public interface IHelpDeskTicket
    {

        string? TicketId { get; }

        string? TicketNumber { get; }

        string? TicketAffectedUserId { get; }

        string? TicketAffectedUserEmail { get; }

        string? TicketAssignedUser { get; }

        string? TicketCreatedBy { get; }

        string? TicketShortDescription { get; }

        string? TicketFullDescription { get; }

        DateTime? TicketCreationDate { get; }

        IEnumerable<IHelpDeskComment> Comments { get; }

        public HelpDeskSeriousness? HelpDeskImpact { get; }

        public HelpDeskSeriousness? HelpDeskUrgency { get; }


    }


    public enum HelpDeskSeriousness
    {
        Critical,
        Major,
        Moderate,
        Minor,
        Request
    }
}



