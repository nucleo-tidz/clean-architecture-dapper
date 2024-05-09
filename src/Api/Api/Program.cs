using Api;
using Microsoft.AspNetCore.Builder;
using NSwag;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Host.ConfigureAppConfiguration((hostingContext, config) =>
{
    var env = hostingContext.HostingEnvironment;
    config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
        .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);
    config.AddEnvironmentVariables();
});
builder.Services.AddServices(builder.Configuration)
    .AddSwagger().AllowCors(builder.Configuration).AddHealthCheck();
var app = builder.Build();
app.UseOpenApi();
app.UseRouting();
app.MapControllers();
app.UseSwaggerUi(c => { c.Path = string.Empty; });
app.MapHealthChecks("/health/ready").AllowAnonymous();
app.MapHealthChecks("/health/live").AllowAnonymous();
app.UseCors("CorsPolicy");
await app.RunAsync();