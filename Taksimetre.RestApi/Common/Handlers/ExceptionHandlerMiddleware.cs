using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace Taksimeter.RestApi.Common.Handlers
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            await _next.Invoke(httpContext);        
        }
    }
}
