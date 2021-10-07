using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using VehiclesAccounting.Infrastructure.Data;

namespace VehiclesAccounting.Web
{
    /// <summary>
    /// Entry point to ASP app
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Constructor of class startup
        /// </summary>
        /// <param name="configuration">Configuration</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        /// <summary>
        /// Gets configuration
        /// </summary>
        public IConfiguration Configuration { get; }
        /// <summary>
        /// Method to registrate services
        /// </summary>
        /// <param name="services">Services</param>
        public void ConfigureServices(IServiceCollection services)
        {
            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<VehiclesContext>(options =>
                options.UseSqlServer(connection, b => b.MigrationsAssembly("VehiclesAccounting.Web")));
            services.AddControllersWithViews();
        }
        /// <summary>
        /// Method to set how app will process the request
        /// </summary>
        /// <param name="app">IApplicationBuilder object</param>
        /// <param name="env">IWebHostEnvironment object</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
