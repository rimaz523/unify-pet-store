using Microsoft.Extensions.Hosting;
using Application;
using Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using ConsoleApp.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Common;

namespace ConsoleApp
{
    public static class Program
    {
        static void Main(string[] args)
        {
            HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
            
            //Wire up IOptions for Console App
            builder.Configuration.Sources.Clear();
            builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            builder.Configuration.GetSection(nameof(IntegrationOptions)).Bind(new IntegrationOptions());

            //Add Application and Infrastrucure layer dependency injection
            builder.Services.AddApplication();
            builder.Services.AddInfrastructure();

            //Add console application and run
            builder.Services.AddScoped<IApplication, Application>();
            IHost _host = builder.Build();
            var app = _host.Services.GetRequiredService<IApplication>();
            app.Run().Wait();
        }
    }
}
