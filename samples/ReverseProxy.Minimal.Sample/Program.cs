var builder = WebApplication.CreateBuilder(args);

builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

var app = builder.Build();

app.Use((context, next) =>
{
    context.Request.EnableBuffering();
    return next(context);
});

app.MapReverseProxy();

app.Run();
