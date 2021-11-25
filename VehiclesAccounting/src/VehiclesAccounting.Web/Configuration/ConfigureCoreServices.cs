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
            services.AddScoped(typeof(ITrafficPoliceOfficerService), typeof(TrafficPoliceOfficerService));
            services.AddScoped(typeof(IOwnerService), typeof(OwnerService));
            services.AddScoped(typeof(ICarBrandService), typeof(CarBrandService));
            services.AddScoped(typeof(ICarService), typeof(CarService));
            services.AddScoped(typeof(IStolenCarService), typeof(StolenCarService));
            return services;
        }
    }
}
