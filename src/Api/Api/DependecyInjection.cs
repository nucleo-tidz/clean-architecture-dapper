using Api.Startup;
using Api.StartupTask;
using Applictaion;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using NSwag;
using NSwag.Generation.AspNetCore;
using NSwag.Generation.Processors.Security;
namespace Api
{
    public static class DependecyInjection
    {

        internal static IServiceCollection AddServices(this IServiceCollection self, IConfiguration configuration)
        {
            self.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.WriteIndented = true;
            });
            self.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            self.AddApplication()
                .AddInfrastructure()
                .AddTransient<IStartupTask, LoadData>()
                .AddTransient<IStartupTask, Inform>();
            return self;
        }

        internal static IServiceCollection AllowCors(this IServiceCollection self, IConfiguration configuration)
        {
            self.AddCors(
           options =>
           {
               string[] allowedOrigins = configuration.GetSection("CorsAllowedOrigins").Get<string[]>();
               string? env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

               options.AddPolicy("CorsPolicy",
                   builder => builder.WithOrigins(allowedOrigins)
                       .AllowAnyMethod()
                       .AllowAnyHeader());
           });
            return self;
        }
        internal static IServiceCollection AddSwagger(this IServiceCollection self)
        {
            self.AddEndpointsApiExplorer();
            self.AddOpenApiDocument(configure => ConfigureSwagger(configure, "v3"));
            //self.AddOpenApiDocument(configure => ConfigureSwagger(configure, "v2"));
            return self;
        }

        private static void ConfigureSwagger(AspNetCoreOpenApiDocumentGeneratorSettings configure, string version)
        {
            configure.PostProcess = doc =>
            {
                doc.Info.License = new OpenApiLicense
                {
                    Name = "Ahmar",

                };
                doc.ExternalDocumentation = new OpenApiExternalDocumentation { Description = "Nucleotidz PlayGround" };

            };

            configure.Title = "Nucleotidz.Api";
            configure.OperationProcessors.Add(new AspNetCoreOperationSecurityScopeProcessor("JWT"));
            configure.DocumentName = version;
        }
        internal static IServiceCollection AddHealthCheck(this IServiceCollection self)
        {

            self.AddHealthChecks()
                 .AddCheck("Live Probe", _ => HealthCheckResult.Healthy());

            return self;
        }
    }
}
