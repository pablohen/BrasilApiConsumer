using Refit;

namespace BrasilApiConsumer.Middleware;

public class RefitExceptionMiddleware(
    RequestDelegate next,
    ILogger<RefitExceptionMiddleware> logger
)
{
    private readonly RequestDelegate _next = next;
    private readonly ILogger<RefitExceptionMiddleware> _logger = logger;

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (ApiException ex)
        {
            _logger.LogError(
                ex,
                "API exception occurred: {StatusCode} - {Reason}",
                ex.StatusCode,
                ex.ReasonPhrase
            );
            context.Response.StatusCode = (int)ex.StatusCode;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(ex.Content ?? string.Empty);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unhandled exception occurred");
            throw;
        }
    }
}
