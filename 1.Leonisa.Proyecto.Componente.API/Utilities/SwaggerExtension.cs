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

// Namespace que contiene la extensión Swagger
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.OpenApi.Models;

namespace _1.Leonisa.Proyecto.Componente.API.Utilities
{
    /// <summary>
    /// Clase que define una extensión para configurar Swagger.
    /// </summary>
    public static class SwaggerExtension
    {
        /// <summary>
        /// Método que agrega la configuración personalizada para SwaggerGen.
        /// </summary>
        /// <param name="services">La colección de servicios de la aplicación.</param>
        public static void AddCustomSwaggerGen(this IServiceCollection services)
        {
            // Agregar el generador de exploradores de puntos finales
            services.AddEndpointsApiExplorer();

            // Configuración del generador de Swagger
            services.AddSwaggerGen(options =>
            {
                // Definición de documentos Swagger para diferentes versiones de la API
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

                // Definición de la seguridad basada en JWT
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme.",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "bearer",
                    BearerFormat = "JWT"
                });

                // Requisito de seguridad para usar JWT en las operaciones
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

                // Incluir comentarios XML en la documentación Swagger
                List<string> xmlFiles = Directory.GetFiles(AppContext.BaseDirectory, "*.xml", SearchOption.TopDirectoryOnly).ToList();
                xmlFiles.ForEach(xmlFile => options.IncludeXmlComments(xmlFile));
            });
        }

        /// <summary>
        /// Método que agrega la configuración personalizada para usar Swagger UI.
        /// </summary>
        /// <param name="app">La aplicación ASP.NET Core.</param>
        public static void AddCustomUseSwaggerUI(this WebApplication app)
        {
            // Configuración para usar Swagger
            app.UseSwagger(options =>
            {
                options.SerializeAsV2 = true;
            });

            // Obteniendo el proveedor de descripciones de versión de API
            var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

            // Configuración de Swagger UI
            app.UseSwaggerUI(c =>
            {
                // Agregando endpoints Swagger para cada versión de la API
                foreach (var GroupName in apiVersionDescriptionProvider.ApiVersionDescriptions.Reverse().Select(x => x.GroupName))
                {
                    c.SwaggerEndpoint($"/swagger/{GroupName}/swagger.json", GroupName.ToUpperInvariant());
                }
                // Mostrar la duración de las solicitudes en Swagger UI
                c.DisplayRequestDuration();
            });
        }
    }
}
