// ***********************************************************************
// Assembly         : 1.Leonisa.Proyecto.Componente.API
// Author           : Arq. Elkin Torres
// Created          : 07-13-2023
//
// Last Modified By : Arq. Elkin Torres
// Last Modified On : Arq. Elkin Torres
// ***********************************************************************
// <copyright file="Program.cs" company="1.Leonisa.Proyecto.Componente.API">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using _1.Leonisa.Proyecto.Componente.API.Utilities;

using _2.Leonisa.Proyecto.Componente.Service;

namespace _1.Leonisa.Proyecto.Componente.API
{
    /// <summary>
    /// Class Program.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            //Configure IoC (Services, Repositories, Gateway)
            builder.Services.ConfigureIoC();

            //Configure Security (Authentication, Autorization, CORS)
            builder.Services.AddCustomSecurity(builder.Configuration);


            builder.Services
              .AddControllers(config =>
              {
                  config.Filters.Add(typeof(ExceptionFilter));
              });

            builder.Services.AddCustomApiVersioning();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddCustomSwaggerGen();

            builder.Services.AddCustomHealthChecks(builder.Configuration);
            //=============================================================
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.AddCustomUseSwaggerUI();
            }
            app.MapHealthChecks("/hc").AllowAnonymous();

            app.UseHttpsRedirection();

            app.UseCors("CustomCORS");

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}