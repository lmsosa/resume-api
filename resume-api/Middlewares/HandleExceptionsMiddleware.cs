using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Resume.Application.Exceptions;
using Resume.WebApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Resume.Api.Middlewares
{
    /// <summary>
    /// Middleware encargado de atrapar excepciones no controladas y proveer respuestas Http útiles
    /// </summary>
    public class HandleExceptionsMiddleware
    {
        private readonly RequestDelegate _next;

        /// <summary>
        /// Initializes a new instance of the <see cref="HandleExceptionsMiddleware"/> class.
        /// </summary>
        /// <param name="next"> Next action on the request processing pipeline </param>
        public HandleExceptionsMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// Performs the specific action of this middleware. Invoke is executed internally by AspNet Core framework
        /// </summary>
        /// <param name="context"> Http context for the request being processed </param>
        /// <returns> No object or value is returned by this method when it completes </returns>
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError;

            if (exception is NotFoundException) code = HttpStatusCode.NotFound;
            if (exception is ValidationException) code = HttpStatusCode.BadRequest;

            var result = JsonConvert.SerializeObject(ErrorDetails.For(exception.Message));
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            await context.Response.WriteAsync(result);
        }
    }

}
