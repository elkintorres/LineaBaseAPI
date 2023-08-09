using Microsoft.AspNetCore.Mvc;

namespace _1.Leonisa.Proyecto.Componente.API.Utilities
{
    public static class ApiVersioningExtesion
    {
        /// <summary>
        /// Adds the custom API versioning.
        /// </summary>
        /// <param name="services">The services.</param>
        public static void AddCustomApiVersioning(this IServiceCollection services)
        {
            services
                .AddApiVersioning(options =>
                {
                    options.DefaultApiVersion = new ApiVersion(1, 0);
                    options.AssumeDefaultVersionWhenUnspecified = true;
                    options.ReportApiVersions = true;
                })
                .AddVersionedApiExplorer(options =>
                {
                    options.GroupNameFormat = "'v'VVV";
                    options.SubstituteApiVersionInUrl = true;
                    options.AssumeDefaultVersionWhenUnspecified = false;
                });
        }
    }
}
