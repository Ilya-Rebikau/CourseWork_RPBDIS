using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using VehiclesAccounting.Infrastructure.Data;

namespace VehiclesAccounting.Web.Middlewares
{
    public class DbInitializerMiddleware
    {
        private readonly RequestDelegate _next;
        public DbInitializerMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public Task Invoke(HttpContext context, VehiclesContext db)
        {
            DbInitializer.Initialize(db);
            return _next.Invoke(context);
        }
    }
}
