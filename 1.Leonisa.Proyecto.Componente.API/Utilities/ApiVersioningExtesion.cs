using Microsoft.AspNetCore.Mvc;

namespace _1.Leonisa.Proyecto.Componente.API.Utilities
{
    /// <summary>
    /// Class ApiVersioningExtesion.
    /// </summary>
    public static class ApiVersioningExtesion
    {
        /// <summary>
        /// Adds the custom API versioning.
        /// </summary>
        /// <param name="services">The services.</param>
        public static void AddCustomApiVersioning(this IServiceCollection services)
        {
            // Agrega la versión de la API y configura opciones relacionadas
            services.AddApiVersioning(options =>
            {
                // Establece la versión predeterminada de la API
                options.DefaultApiVersion = new ApiVersion(1, 0);

                // Si no se especifica una versión, asume la versión predeterminada
                options.AssumeDefaultVersionWhenUnspecified = true;

                // Habilita la generación de informes de versiones de API en las respuestas
                options.ReportApiVersions = true;
            })
            // Agrega el explorador de API versionadas y configura opciones relacionadas
            .AddVersionedApiExplorer(options =>
            {
                // Define el formato de los nombres de los grupos de versiones en el explorador
                options.GroupNameFormat = "'v'VVV";

                // Sustituye la versión en las URL automáticamente
                options.SubstituteApiVersionInUrl = true;

                // No asumas automáticamente la versión predeterminada si no se especifica
                options.AssumeDefaultVersionWhenUnspecified = false;
            });
        }

    }
}
