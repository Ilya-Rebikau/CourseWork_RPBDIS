using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using VehiclesAccounting.Infrastructure.Data;

namespace VehiclesAccounting.Web
{
    /// <summary>
    /// Main class
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Entry point to the program
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            IHost host = CreateHostBuilder(args).Build();
            using (IServiceScope scope = host.Services.CreateScope())
            {
                IServiceProvider services = scope.ServiceProvider;
                try
                {
                    VehiclesContext context = services.GetRequiredService<VehiclesContext>();
                    context.Database.Migrate();
                    context.Database.EnsureCreated();
                }
                catch (Exception ex)
                {
                    ILogger<Program> logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred seeding the DB.");
                }
            }
            host.Run();
        }
        /// <summary>
        /// Method to create IHost object to start program
        /// </summary>
        /// <param name="args"></param>
        /// <returns>IHostBuilder object</returns>
        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
.UseServiceProviderFactory(new AutofacServiceProviderFactory())
.ConfigureWebHostDefaults(webBuilder =>
{
    webBuilder
    .UseStartup<Startup>()
    .ConfigureLogging(logging =>
    {
        logging.ClearProviders();
        logging.AddConsole();
    });
});
        }
    }
}
