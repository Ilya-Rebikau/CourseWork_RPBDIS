using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using VehiclesAccounting.Infrastructure.Data;

namespace VehiclesAccounting.Web.Middlewares
{
    public class RoleInitializerMiddleware
    {
        private readonly RequestDelegate _next;
        public RoleInitializerMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public Task Invoke(HttpContext context)
        {
            RoleInitializer.Initialize(context).Wait();
            return _next.Invoke(context);
        }
    }
}
