using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MyFinance.BLL.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyFinance.API.Infrastructure
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IHostEnvironment _environment;
        private readonly ILogger<ErrorHandlerMiddleware> _logger;

        public ErrorHandlerMiddleware(
            RequestDelegate next, 
            IHostEnvironment environment,
            ILogger<ErrorHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
            _environment = environment;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                if(error is CustomBLLException)
                {
                    response.StatusCode = error switch
                    {
                        ValueNotFoundException or ValueNotSpecifiedException or ValueOutOfRangeException => (int)HttpStatusCode.NotFound,
                        ValueConflictException => (int)HttpStatusCode.Conflict,
                        NoContentException => (int)HttpStatusCode.NoContent,
                        _ => (int)HttpStatusCode.BadRequest,
                    };
                }
                else
                {
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                }

                _logger.LogError(error, error.Message);
                await response.WriteAsync(GetErrorMessageJson(error));
            }
        }

        private string GetErrorMessageJson(Exception error)
        {
            return JsonSerializer.Serialize(new
            {
                message = error?.Message,
                details = _environment.IsDevelopment() ? GetInnerExceptions(error) : null,
            });
        }
        
        private static IEnumerable<string> GetInnerExceptions(Exception ex)
        {
            var messages = new List<string>();

            while (ex?.InnerException != null)
            {
                messages.Add(ex.InnerException.Message);
                ex = ex.InnerException;
            } 
            return messages;
        }
    }
}
