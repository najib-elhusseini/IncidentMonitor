namespace IncidentMonitor.Services
{
    public class IncidentBackgroundMonitorService : BackgroundService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        PeriodicTimer timer;
        int count = 0;

        public int Count => count;

        public IncidentBackgroundMonitorService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
            timer = new PeriodicTimer(TimeSpan.FromSeconds(10));

        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            bool run;
            do
            {
                run = stoppingToken.IsCancellationRequested == false;
                run = run && await timer.WaitForNextTickAsync(stoppingToken);
                count++;

            } while (run);
        }
    }
}
