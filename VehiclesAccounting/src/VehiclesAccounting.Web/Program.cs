using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace VehiclesAccounting.Web;

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
    /// Create IHost object to start program
    /// </summary>
    /// <param name="args"></param>
    /// <returns>IHostBuilder object</returns>
    public static IHostBuilder CreateHostBuilder(string[] args)
    {
        return Host.CreateDefaultBuilder(args)
.ConfigureWebHostDefaults(webBuilder =>
{
    webBuilder.UseStartup<Startup>();
});
    }
}
