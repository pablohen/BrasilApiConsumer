using BrasilApiConsumer.Middleware;

namespace BrasilApiConsumer.Extensions;

public static class MiddlewareExtensions
{
    public static IApplicationBuilder UseRefitExceptionHandling(this IApplicationBuilder app)
    {
        return app.UseMiddleware<RefitExceptionMiddleware>();
    }
}
