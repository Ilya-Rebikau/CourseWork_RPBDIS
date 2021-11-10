using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

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
            CreateHostBuilder(args).Build().Run();
        }
        /// <summary>
        /// Method to create IHost object to start program
        /// </summary>
        /// <param name="args"></param>
        /// <returns>IHostBuilder object</returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}