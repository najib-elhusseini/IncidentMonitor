

using IncidentMonitor.Controllers;
using IncidentMonitor.DataLayer.Data;
using IncidentMonitor.DataLayer.Helpers;
using IncidentMonitor.DataLayer.Models;
using IncidentMonitor.Models;
using IncidentMonitor.Models.Assyst;
using IncidentMonitor.Models.RemedyForce;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Net.WebSockets;

namespace IncidentMonitor.Services
{
    public class IncidentBackgroundMonitorService : BackgroundService
    {
        static string DataSource => "Data Source=incident_monitor.db";

        #region Props

        public List<EventDto> Incidents { get; private set; } = new();
        public List<EventDto> UnrespondedIncidents { get; private set; } = new();

        private DataLayerHelperEntity DataLayerHelper { get; set; }
        #endregion

        bool firstRun = true;
        bool isLoading = false;
        PeriodicTimer timer;

        #region Ctor

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public IncidentBackgroundMonitorService()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            ConstructDataContext();

            timer = new PeriodicTimer(TimeSpan.FromMinutes(1));
        }

        private void ConstructDataContext()
        {
            DbContextOptionsBuilder<ApplicationDbContext> builder = new();
            builder.UseSqlite(DataSource);
            ApplicationDbContext context = new(builder.Options);
            DataLayerHelper = new(context);
        }
        #endregion


        public async Task GetIncidents()
        {
            if (isLoading)
            {
                return;
            }
            isLoading = true;
            ConstructDataContext();
            try
            {
                if (DataLayerHelper.AssystEventsHelper == null)
                {
                    return;
                }
                List<EventDto> events = new();

                bool done = false;
                do
                {
                    var skip = events.Count;
                    var result = await DataLayerHelper.AssystEventsHelper.GetTodayOpenIncidents(skip);
                    events.AddRange(result.todayEvents);
                    if (result.done)
                    {
                        done = true;
                    }

                } while (!done);
                Incidents = events;
                UnrespondedIncidents = events.Where(e => e.Acknowledged != true).ToList();
                NotifyUsers();
                isLoading = false;
            }
            catch (Exception ex)
            {
#if DEBUG
                Debug.WriteLine(ex);
#endif

            }

        }

        private void NotifyUsers()
        {
            try
            {
                var users = DataLayerHelper.UsersHelper.GetHelpDeskUsers();
                Dictionary<ApplicationUser, List<EventDto>> UsersToNotify = new();
                var config = DataLayerHelper.SmtpConfigHelper.Get();
                if (config == null) return;
                var emailHelper = new EmailHelper(config);

                foreach (var user in users)
                {
                    foreach (var incident in UnrespondedIncidents)
                    {
                        if (incident.GetEventAcknowledgedStatus(user) != EventAcknowledgedStatus.UnrespondedInShift)
                        {
                            continue;
                        }
                        if (!UsersToNotify.ContainsKey(user))
                        {
                            UsersToNotify.Add(user, new List<EventDto>());
                        }
                        UsersToNotify[user].Add(incident);
                    }
                }
                foreach (var user in UsersToNotify)
                {
                    _ = emailHelper.SendUnrespondedNotificationEmailsAsync(user.Value, user.Key);
                }
            }
            catch (Exception ex)
            {


            }

        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            if (firstRun)
            {
                await GetIncidents();
                firstRun = false;
            }


            bool run;
            do
            {
                run = stoppingToken.IsCancellationRequested == false;
                run = run && await timer.WaitForNextTickAsync(stoppingToken);
                await GetIncidents();
            } while (run);
        }


    }
}
