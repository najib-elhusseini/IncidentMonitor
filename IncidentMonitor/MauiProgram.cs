
using Microsoft.Extensions.Logging;


namespace IncidentMonitor
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();                
            builder
                .UseMauiApp<App>()                
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans_Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans_Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("bootstrap.ttf", "BootStrap");
                });
            

#if DEBUG
		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}