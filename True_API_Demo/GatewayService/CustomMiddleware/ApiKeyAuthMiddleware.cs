namespace GatewayService.CustomMiddleware
{
    public class ApiKeyAuthMiddleware(RequestDelegate next)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            // 只拦截需要认证的路由（可根据路径过滤）
            if (context.Request.Path.StartsWithSegments("/api"))
            {
                if (!context.Request.Headers.TryGetValue("X-API-Key", out var apiKey) || apiKey != "secret-key-123")
                {
                    context.Response.StatusCode = 401;
                    await context.Response.WriteAsync("Unauthorized: Invalid or missing API Key");
                    return;
                }
            }
            await next(context);
        }
    }
}
