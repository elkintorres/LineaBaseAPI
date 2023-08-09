// ***********************************************************************
// Assembly         : 1.Leonisa.Proyecto.Componente.API
// Author           : Arq. Elkin Torres
// Created          : 07-26-2023
//
// Last Modified By : Arq. Elkin Torres
// Last Modified On : Arq. Elkin Torres
// ***********************************************************************
// <copyright file="SwaggerExtension.cs" company="1.Leonisa.Proyecto.Componente.API">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

namespace _1.Leonisa.Proyecto.Componente.API.Utilities
{
    /// <summary>
    /// Class SwaggerExtension.
    /// </summary>
    public static class SwaggerExtension
    {
        /// <summary>
        /// Adds the custom swagger gen.
        /// </summary>
        /// <param name="services">The services.</param>
        public static void AddCustomSwaggerGen(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = new string("Swagger API REST ServiceName V1")
                });

                options.SwaggerDoc("v2", new OpenApiInfo
                {
                    Version = "v2",
                    Title = new string("Swagger API REST ServiceName V2")
                });

                //options.DocInclusionPredicate((name, api) => true);

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme.",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "bearer",
                    BearerFormat = "JWT"
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Name = "Bearer",
                            Type = SecuritySchemeType.ApiKey,
                            In = ParameterLocation.Header,
                            BearerFormat = "JWT",
                            Scheme = "Bearer",
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                         },
                        Array.Empty<string>()
                     }
                });

                List<string> xmlFiles = Directory.GetFiles(AppContext.BaseDirectory, "*.xml", SearchOption.TopDirectoryOnly).ToList();
                xmlFiles.ForEach(xmlFile => options.IncludeXmlComments(xmlFile));
            });
        }

        /// <summary>
        /// Adds the custom use swagger UI.
        /// </summary>
        /// <param name="app">The application.</param>
        public static void AddCustomUseSwaggerUI(this WebApplication app)
        {
            app.UseSwagger(options =>
            {
                options.SerializeAsV2 = true;
            });

            var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

            app.UseSwaggerUI(c =>
            {
                foreach (var GroupName in apiVersionDescriptionProvider.ApiVersionDescriptions.Reverse().Select(x => x.GroupName))
                {
                    c.SwaggerEndpoint($"/swagger/{GroupName}/swagger.json", GroupName.ToUpperInvariant());
                }
                c.DisplayRequestDuration();
            });
        }
    }
}
