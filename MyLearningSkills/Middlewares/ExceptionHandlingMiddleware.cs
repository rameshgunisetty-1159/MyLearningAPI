using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using MyLearningSkills.Infrastructure;

namespace MyLearningSkills.API.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ApiException ex)
            {
                _logger.LogError(ex, "API Exception occurred: {Message}", ex.Message);
                context.Response.StatusCode = ex.ErrorCode;
                context.Response.ContentType = "application/json";
                var errorResponse = new { error = ex.Message, code = ex.ErrorCode , details = ex.Details , traceId = context.TraceIdentifier };
                await context.Response.WriteAsJsonAsync(errorResponse);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 500;
                context.Response.ContentType = "application/json";
                var errorResponse = new { Message = ex.Message };
                await context.Response.WriteAsJsonAsync(errorResponse);
            }
        }
    }
}
