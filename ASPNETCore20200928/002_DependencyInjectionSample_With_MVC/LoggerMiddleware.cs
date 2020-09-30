using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Serilog;

namespace _002_DependencyInjectionSample_With_MVC
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class LoggerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly Microsoft.Extensions.Logging.ILogger _logger;

        public LoggerMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<LoggerMiddleware>();
        }

        public async Task Invoke(HttpContext httpContext)
        {
            //Logik der Middleware

            using (var reader = new StreamReader(httpContext.Request.Body))
            {
                Task<string> requestBody =  reader.ReadToEndAsync();

                requestBody.Wait();

                //https://medium.com/swlh/asp-net-core-custom-middleware-89206c27f22b
                _logger.LogInformation(requestBody.Result);
                Log.Information(requestBody.Result);
            }

            await _next.Invoke(httpContext);
            //return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class LoggerMiddlewareExtensions
    {
        public static IApplicationBuilder UseLoggerMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LoggerMiddleware>();
        }
    }
}
