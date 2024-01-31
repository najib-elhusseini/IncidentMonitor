using IncidentMonitor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using System.ComponentModel.DataAnnotations;
using System.Collections;

namespace IncidentMonitor.DataLayer.Helpers
{
    public class EmailHelper
    {
        private const string _userName = "hoist.leb@gmail.com";
        private const string _appPassword = "hhmo pjhz rbaq ulwk";

        protected EmailConfiguration EmailConfiguration { get; set; }

        public EmailHelper(EmailConfiguration emailConfiguration)
        {
            EmailConfiguration = emailConfiguration;
        }

        public async Task SendIncidentsNotificationEmailAsync
            (IEnumerable<Models.RemedyForce.Incident> incidents, IEnumerable<NotificationUser> users)
        {
            var userEmails = users.Select(x => x.Email ?? "").ToArray();
            if (userEmails == null || !userEmails.Any())
            {
                return;
            }
            var subject = $"Incidents detected";

            StringBuilder sb = new();
            sb.Append("<html><body>");
            sb.Append($"<b>Incidents detected ({incidents.Count()})</b>");
            sb.Append("<br/><ul>");
            foreach (var incident in incidents)
            {
                sb.Append("<li>");
                sb.Append('#');
                sb.Append(incident.IncidentName);
                sb.Append("&nbsp;&nbsp;");
                sb.Append(incident.ClientAccountName ?? "");
                sb.Append(" - ");
                sb.Append(incident.Client?.Username ?? "");
                sb.Append("&nbsp;&nbsp;");
                sb.Append(incident.Title);
                sb.Append("</li>");
            }
            sb.Append("</ul></body></html>");
            var body = sb.ToString();

            await SendEmailAsync(subject, body, null, userEmails);
        }


        public async Task SendUnrespondedNotificationEmailsAsync
            (IEnumerable<Models.RemedyForce.Incident> incidents, IEnumerable<NotificationUser> users)
        {
            var userEmails = users.Select(x => x.Email ?? "").ToArray();
            if (userEmails == null || !userEmails.Any())
            {
                return;
            }
            var subject = $"Unresponded incidents detected";

            StringBuilder sb = new();
            sb.Append("<html><body>");
            sb.Append($"<b>Unresponded incidents detected ({incidents.Count()})</b>");
            sb.Append("<br/><ul>");
            foreach (var incident in incidents)
            {
                sb.Append("<li>");
                sb.Append('#');
                sb.Append(incident.IncidentName);
                sb.Append("&nbsp;&nbsp;");
                sb.Append(incident.ClientAccountName ?? "");
                sb.Append(" - ");
                sb.Append(incident.Client?.Username ?? "");
                sb.Append("&nbsp;&nbsp;");
                sb.Append(incident.Title);
                sb.Append("</li>");
            }
            sb.Append("</ul></body></html>");
            var body = sb.ToString();
            
            await SendEmailAsync(subject, body, null, userEmails);

        }






        public async Task SendEmailAsync(
            string subject,
            string htmlBody,
            SendCompletedEventHandler? sendCompletedEventHandler = null,
            params string[] receipients
            )
        {
            if (!EmailConfiguration.CheckValidity())
            {
                throw new ArgumentNullException("One or more required properties is invalid");
            }
            if (receipients.Length == 0)
            {
                return;
            }
            string recepientEmailAddress = receipients[0];

            using SmtpClient client = new(EmailConfiguration.SmtpClientName)
            {
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(EmailConfiguration.UserName, EmailConfiguration.Password),
                EnableSsl = EmailConfiguration.EnableSsl,
                Port = EmailConfiguration.SmtpPort ?? 0,
            };
            client.SendCompleted += sendCompletedEventHandler;


            using MailMessage message = new(EmailConfiguration.UserName!, recepientEmailAddress)
            {
                IsBodyHtml = true,
                Body = htmlBody,
                Subject = subject,
            };
            if (receipients.Length > 1)
            {
                for (int i = 1; i < receipients.Length; i++)
                {
                    message.To.Add(receipients[i]);
                }
            }


            try
            {
                await client.SendMailAsync(message);
            }
            catch (Exception)
            {

                throw;
            }


        }

    }
}
