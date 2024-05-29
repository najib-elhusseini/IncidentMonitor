
using Microsoft.Extensions.DependencyInjection;
using IncidentMonitor.DataLayer.Data;
using IncidentMonitor.Services;

using Microsoft.Extensions.DependencyInjection;
using IncidentMonitor.DataLayer.Helpers;
using Microsoft.EntityFrameworkCore;
using IncidentMonitor.DataLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace IncidentMonitor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
            }).AddDefaultIdentity<ApplicationUser>(options =>
            {
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireDigit = false;

            })
            .AddRoles<ApplicationRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>();

            builder.Services.AddAuthentication(options =>
            {

            });


            builder.Services.AddScoped<IDataLayerHelperEntity, DataLayerHelperEntity>();
            builder.Services.AddScoped<IDatabaseInitializer, DatabaseInitializer>();
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

            using var scope = app.Services.CreateScope();
            var provider = scope.ServiceProvider;
            //var webHostEnv = provider.GetRequiredService<IWebHostEnvironment>();
            var dbInitializer = provider.GetRequiredService<IDatabaseInitializer>();
            dbInitializer.Initialize()
                .GetAwaiter().GetResult();

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