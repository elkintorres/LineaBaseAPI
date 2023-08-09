using Microsoft.AspNetCore.Authentication.JwtBearer; //tener cuidado con la version del paquete
using Microsoft.IdentityModel.Tokens;

using System.Security.Claims;
using System.Text;

namespace _1.Leonisa.Proyecto.Componente.API.Utilities
{
    /// <summary>
    /// Class SecurityExtension.
    /// </summary>
    public static class SecurityExtension
    {
        /// <summary>
        /// Adds the custon security.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="configuration">The configuration.</param>
        public static void AddCustomSecurity(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCustomAuthentication(configuration);
            services.AddCustomAutorization();
            services.AddCustomCORS();
        }

        /// <summary>
        /// Adds the custom authentication.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="configuration">The configuration.</param>
        public static void AddCustomAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtTokenConfig = configuration.GetSection("JwtConfig").Get<JwtTokenConfig>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
           // Adding Jwt Bearer
           .AddJwtBearer(options =>
           {
               //options.SaveToken = true;
               //options.RequireHttpsMetadata = true;
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
        /// Adds the custom autorization.
        /// </summary>
        /// <param name="services">The services.</param>
        public static void AddCustomAutorization(this IServiceCollection services)
        {
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
        /// Adds the custom cors.
        /// </summary>
        /// <param name="services">The services.</param>
        public static void AddCustomCORS(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: "CustomCORS", policy =>
                {
                    //policy.WithOrigins("https://example.com", "http://localhost:3000")Esto puede reducir el riesgo de ataques CSRF (Cross-Site Request Forgery) 
                    policy.AllowAnyOrigin()
                    .WithMethods("GET", "POST", "PUT", "DELETE")
                    .WithHeaders("Content-Type", "Authorization");
                });
            });
        }
    }
}
