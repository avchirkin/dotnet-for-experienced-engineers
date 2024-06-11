namespace WebApiWithControllers.Middleware;

public static class ServiceCollectionExtensions
{
    public static IApplicationBuilder UseTestRequestsHandler(this IApplicationBuilder app)
    {
        return app.UseMiddleware<TestRequestsHandler>();
    }
}