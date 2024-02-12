
using Microsoft.Extensions.DependencyInjection;
using IncidentMonitor.DataLayer.Data;
using IncidentMonitor.Services;

using Microsoft.Extensions.DependencyInjection;
using IncidentMonitor.DataLayer.Helpers;

namespace IncidentMonitor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


          
          
            
            builder.Services.AddControllersWithViews();
            builder.Services.AddSingleton<IncidentBackgroundMonitorService>();
            builder.Services.AddHostedService(provider =>
            {
                return provider.GetRequiredService<IncidentBackgroundMonitorService>();
            });

          

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();


            app.MapControllerRoute(
                name: "default",
                pattern: "{controller}/{action=Index}/{id?}");

            app.MapFallbackToFile("index.html");

            app.Run();
        }
    }
}