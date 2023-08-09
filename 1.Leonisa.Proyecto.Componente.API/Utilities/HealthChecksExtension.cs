using _1.Leonisa.Proyecto.Componente.API.Utilities.HealthCheck;

using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace _1.Leonisa.Proyecto.Componente.API.Utilities
{
    public static class HealthChecksExtension
    {
        public static void AddCustomHealthChecks(this IServiceCollection services, IConfiguration configuration)
        {
            //https://learn.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/monitor-app-health
            services.AddHealthChecks()
                .AddCheck(
                    "DataBase-check",
                    new SqlConnectionHealthCheck(configuration.GetConnectionString("ConnectionString")),
                    HealthStatus.Unhealthy,
                    new string[] { "Northwind" });

        }
    }
}
