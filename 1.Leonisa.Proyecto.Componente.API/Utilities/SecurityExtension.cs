using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

using System.Security.Claims;
using System.Text;

namespace _1.Leonisa.Proyecto.Componente.API.Utilities
{
    /// <summary>
    /// Clase que contiene extensiones para configurar la seguridad en la API.
    /// </summary>
    public static class SecurityExtension
    {
        /// <summary>
        /// Método que agrega la configuración de seguridad personalizada.
        /// </summary>
        /// <param name="services">La colección de servicios de la aplicación.</param>
        /// <param name="configuration">La configuración de la aplicación.</param>
        public static void AddCustomSecurity(this IServiceCollection services, IConfiguration configuration)
        {
            // Agregar la configuración personalizada de autenticación
            services.AddCustomAuthentication(configuration);

            // Agregar la configuración personalizada de autorización
            services.AddCustomAutorization();

            // Agregar la configuración personalizada de CORS
            services.AddCustomCORS();
        }

        /// <summary>
        /// Método que agrega la configuración de autenticación personalizada.
        /// </summary>
        /// <param name="services">La colección de servicios de la aplicación.</param>
        /// <param name="configuration">La configuración de la aplicación.</param>
        public static void AddCustomAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            // Obtener la configuración del token JWT
            var jwtTokenConfig = configuration.GetSection("JwtConfig").Get<JwtTokenConfig>();

            // Configurar opciones de autenticación
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            // Agregar JWT Bearer
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtTokenConfig.Secret)),
                    ValidateIssuer = true,
                    ValidIssuer = jwtTokenConfig.Issuer,
                    ValidateAudience = true,
                    ValidAudience = jwtTokenConfig.Audience,
                    ValidateLifetime = true,
                    RequireExpirationTime = true,
                    ClockSkew = TimeSpan.FromMinutes(1)
                };
            });
        }

        /// <summary>
        /// Método que agrega la configuración de autorización personalizada.
        /// </summary>
        /// <param name="services">La colección de servicios de la aplicación.</param>
        public static void AddCustomAutorization(this IServiceCollection services)
        {
            // Configurar políticas de autorización
            services.AddAuthorization(options =>
            {
                options.AddPolicy("Products_Create", policy => policy.RequireClaim("Module", "Products").RequireClaim("Products", "Create").RequireClaim(ClaimTypes.Name));
                options.AddPolicy("Products_Read", policy => policy.RequireClaim("Module", "Products").RequireClaim("Products", "Read").RequireClaim(ClaimTypes.Name));
                options.AddPolicy("Products_Update", policy => policy.RequireClaim("Module", "Products").RequireClaim("Products", "Update").RequireClaim(ClaimTypes.Name));
                options.AddPolicy("Products_Delete", policy => policy.RequireClaim("Module", "Products").RequireClaim("Products", "Delete").RequireClaim(ClaimTypes.Name));
                //options.AddPolicy("FallbackPolicy", policy => policy.RequireAuthenticatedUser()); // Definición de la política de "fallback"
            });
        }

        /// <summary>
        /// Método que agrega la configuración de CORS personalizada.
        /// </summary>
        /// <param name="services">La colección de servicios de la aplicación.</param>
        public static void AddCustomCORS(this IServiceCollection services)
        {
            // Configurar políticas CORS personalizadas
            services.AddCors(options =>
            {
                options.AddPolicy(name: "CustomCORS", policy =>
                {
                    // Permitir cualquier origen y métodos específicos
                    policy.AllowAnyOrigin()
                    .WithMethods("GET", "POST", "PUT", "DELETE")
                    .WithHeaders("Content-Type", "Authorization");
                });
            });
        }
    }
}


