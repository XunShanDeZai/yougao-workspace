using GatewayService.CustomMiddleware;
using Yarp.ReverseProxy;
using Yarp.ReverseProxy.Transforms;
using Yarp.ReverseProxy.Transforms.Builder;

var builder = WebApplication.CreateBuilder(args);

// 注册YARP
builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"))
    .AddTransforms(transformBuilderContext =>
    {
        // 判断当前正在构建的路由是否为 'external-posts-route'
        if (transformBuilderContext.Route?.RouteId == "external-posts-route")
        {
            transformBuilderContext.AddRequestTransform(async transformContext =>
            {
                // 添加自定义请求头
                transformContext.ProxyRequest.Headers.Add("X-Added-Header", "AddedValue");
                await Task.CompletedTask;
            });
        }
    });


var app = builder.Build();

// 全局自定义认证中间件（模拟API Key）
app.UseMiddleware<ApiKeyAuthMiddleware>();

// YARP代理中间件
app.MapReverseProxy();

app.MapGet("/", () => "Hello World!");

app.Run();
