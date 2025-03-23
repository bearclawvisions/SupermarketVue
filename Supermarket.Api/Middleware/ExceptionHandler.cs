using Newtonsoft.Json;
using Supermarket.Business.CustomExceptions;
using System.Net;

namespace Supermarket.Api.Middleware;

public class ExceptionHandler
{
    private readonly RequestDelegate _next;

    public ExceptionHandler(RequestDelegate next)
    {
        _next = next;
    }

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

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";

        int statusCode = (int)HttpStatusCode.InternalServerError;
        string message = "An unexpected error occurred.";

        if (exception is BusinessException businessException)
        {
            statusCode = businessException.StatusCode;
            message = businessException.Message;
        }
        
        if (exception is ValidationException validationException)
        {
            statusCode = validationException.StatusCode;
            message = validationException.Message;
        }
    
        var errorResponse = new
        {
            statusCode,
            message
        };

        context.Response.StatusCode = statusCode;
        await context.Response.WriteAsync(JsonConvert.SerializeObject(errorResponse));
    }
}