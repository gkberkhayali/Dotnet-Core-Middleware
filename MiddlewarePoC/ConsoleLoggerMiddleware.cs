using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace MiddlewarePoC
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ConsoleLoggerMiddleware 
    {
        private readonly RequestDelegate _next;

        public ConsoleLoggerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            httpContext.Response.WriteAsync("<br> ConsoleLoggerMiddleware layer");

            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ConsoleLoggerMiddlewareExtensions
    {
        public static IApplicationBuilder UseConsoleLoggerMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ConsoleLoggerMiddleware>();
        }
    }
}
