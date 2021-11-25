using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using VehiclesAccounting.Core.Interfaces;
using VehiclesAccounting.Core.Services;
using VehiclesAccounting.Infrastructure.Data;

namespace VehiclesAccounting.Web.Configuration
{
    public static class ConfigureCoreServices
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services)
        {
            services.AddScoped<DbContext, VehiclesContext>();
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped(typeof(IServiceAsync<>), typeof(BaseService<>));
            services.AddScoped(typeof(ITrafficPoliceOfficerServiceAsync), typeof(TrafficPoliceOfficerService));
            return services;
        }
    }
}
