namespace WebApiWithControllers.Middleware;

public class TestRequestsHandler(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        var headers = context.Request.Headers;
        if (headers.TryGetValue("test-blow-up", out var values))
        {
            var status = values.FirstOrDefault() ?? string.Empty;

            context.Response.StatusCode = int.Parse(status);
            context.Response.ContentType = "text/plain";
            await context.Response.WriteAsync("This response was replaced");

            return;
        }
        
        await next(context);
    }
}