using Microsoft.AspNetCore.Antiforgery;

public class ValidateAntiForgeryTokenMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IAntiforgery _antiforgery;

    public ValidateAntiForgeryTokenMiddleware(RequestDelegate next, IAntiforgery antiforgery)
    {
        _next = next;
        _antiforgery = antiforgery;
    }

    public async Task Invoke(HttpContext context)
    {
        // Only validate for POST requests with form content
        if (HttpMethods.IsPost(context.Request.Method))
        {
            // Check if antiforgery validation has already been performed
            var antiForgeryFeature = context.Features.Get<IAntiforgeryValidationFeature>();
            if (antiForgeryFeature?.IsValid == false)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsync(antiForgeryFeature.Error.Message + Environment.NewLine + antiForgeryFeature.Error.InnerException);
                return; // Stop further processing
            }

            try
            {
                await _antiforgery.ValidateRequestAsync(context);
            }
            catch (AntiforgeryValidationException ex)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsync(ex.Message + Environment.NewLine + ex.InnerException);
                return; // Stop processing request
            }
        }

        await _next(context);
    }
}