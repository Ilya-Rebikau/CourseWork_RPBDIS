using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using VehiclesAccounting.Core.ProjectAggregate;
using VehiclesAccounting.Infrastructure.Data;
using VehiclesAccounting.Web.Configuration;
using VehiclesAccounting.Web.Middlewares;

namespace VehiclesAccounting.Web;

/// <summary>
/// Entry point to ASP app
/// </summary>
public class Startup
{
    /// <summary>
    /// Constructor of class
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
    /// Registrate services
    /// </summary>
    /// <param name="services">Services</param>
    public void ConfigureServices(IServiceCollection services)
    {
        string connection = Configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<VehiclesContext>(options =>
            options.UseSqlServer(connection, b => b.MigrationsAssembly("VehiclesAccounting.Infrastructure.Data")));
        services.AddDbContext<IdentityContext>(options =>
            options.UseSqlServer(connection, b => b.MigrationsAssembly("VehiclesAccounting.Infrastructure.Data")));
        services.AddControllersWithViews(options =>
            options.CacheProfiles.Add("Caching",
            new CacheProfile()
            {
                NoStore = true,
                Location = ResponseCacheLocation.None,
                //Duration = 300
            }));
        services.AddIdentity<User, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
            .AddEntityFrameworkStores<IdentityContext>();
        services.AddCoreServices();
        services.AddMvc();
    }
    /// <summary>
    /// Set how app will process the request
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

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseMiddleware<DbInitializerMiddleware>();
        app.UseMiddleware<RoleInitializerMiddleware>();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        });
    }
}
