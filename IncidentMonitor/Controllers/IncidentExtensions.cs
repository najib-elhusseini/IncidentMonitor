using IncidentMonitor.DataLayer.Models;
using IncidentMonitor.Models.RemedyForce;
using IncidentMonitor.Models;

namespace IncidentMonitor.Controllers
{
    public static class IncidentExtensions
    {
        public static EventAcknowledgedStatus GetIncidentRespondedStatus(this Incident incident, ApplicationUser user)
        {
            if (incident.IncidentCreationDate == null)
            {
                return EventAcknowledgedStatus.Unknown;
            }
            var helpDeskUser = (user as IHelpDeskObject);
            var responded = !string.IsNullOrWhiteSpace(incident.RespondedDateTime);
            var offset = helpDeskUser.TimeZoneOffset ?? 0;
            var userNow = DateTime.UtcNow.AddHours(offset);
            var incidentCreationDate = incident.IncidentCreationDate.Value.ToUniversalTime().AddHours(offset);

            bool isWithinShift;
            // If it is not in the same day
            if (userNow.Year != incidentCreationDate.Year || userNow.Month != incidentCreationDate.Month || userNow.Day != incidentCreationDate.Day)
            {
                isWithinShift = false;
            }
            else
            {
                isWithinShift = helpDeskUser.IsWithinShift(incidentCreationDate);
            }

            if (isWithinShift)
            {
                return responded ? EventAcknowledgedStatus.RespondedInShift : EventAcknowledgedStatus.UnrespondedInShift;
            }
            return responded ? EventAcknowledgedStatus.RespondedNotInShift : EventAcknowledgedStatus.UnsrespondedNotInShift;

        }
    }
}
