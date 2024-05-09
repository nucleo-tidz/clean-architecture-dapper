using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Api.MiddleWare
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ErrorHandler
    {
        private readonly RequestDelegate _next;

        public ErrorHandler(RequestDelegate next)
        {
            _next = next;
        }

        public  Task Invoke(HttpContext httpContext)
        {
            var exceptionDetails = httpContext.Features.Get<IExceptionHandlerFeature>();
            var exception = exceptionDetails?.Error;
            if (exception?.GetType() == typeof(Applictaion.Common.ValidationException))
            {
                httpContext.Response.StatusCode = 406;
                httpContext.Response.WriteAsJsonAsync(new Error(httpContext.Request.Path, exception.Message, ((Applictaion.Common.ValidationException)exception).Errors)).Wait();
            }
            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ErrorHandlerExtensions
    {
        public static IApplicationBuilder UseErrorHanlder(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorHandler>();
        }
    }
    public record Error(string path, string message, object data);
}
