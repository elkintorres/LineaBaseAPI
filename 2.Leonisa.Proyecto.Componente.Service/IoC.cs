// ***********************************************************************
// Assembly         : 2.Leonisa.Proyecto.Componente.Service
// Author           : Arq. Elkin Torres
// Created          : 07-19-2023
//
// Last Modified By : Arq. Elkin Torres
// Last Modified On : Arq. Elkin Torres
// ***********************************************************************
// <copyright file="IoC.cs" company="2.Leonisa.Proyecto.Componente.Service">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using _4.Leonisa.Proyecto.Componente.Repository;

using _5.Leonisa.Proyecto.Componente.Gateway;

using _6.Leonisa.Proyecto.Componente.Persistence;

using Microsoft.Extensions.DependencyInjection;

namespace _2.Leonisa.Proyecto.Componente.Service
{
    /// <summary>
    /// Class IoC.
    /// </summary>
    public static class IoC
    {
        /// <summary>
        /// Singleton (AddSingleton):
        /// El servicio registrado como singleton se crea una sola vez durante toda la vida de la aplicación y
        /// se reutiliza en todas las solicitudes y componentes que lo requieran.
        /// Transient (AddTransient):
        /// El servicio registrado como transient se crea cada vez que se solicita.Cada solicitud o
        /// componente obtendrá una nueva instancia del servicio.
        /// Scoped (AddScoped):
        /// El servicio registrado como scoped se crea una vez por cada ámbito de solicitud.
        /// Dentro del mismo ámbito, se reutilizará la misma instancia del servicio
        /// </summary>
        /// <param name="services">The services.</param>

        public static void ConfigureIoC(this IServiceCollection services)
        {
            RegisterRepositories(services);
            RegisterClientsHttp(services);
            RegisterServices(services);
        }

        /// <summary>
        /// Registers the services.
        /// </summary>
        /// <param name="services">The services.</param>
        private static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IBaseEntityService, BaseEntityService>();
            services.AddScoped<IProductsService, ProductsService>();
        }

        /// <summary>
        /// Registers the clients HTTP.
        /// </summary>
        /// <param name="services">The services.</param>
        private static void RegisterClientsHttp(IServiceCollection services)
        {
            services.AddScoped<IGenericClientHttp, GenericClientHttp>();
        }

        /// <summary>
        /// Registers the repositories.
        /// </summary>
        /// <param name="services">The services.</param>
        private static void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped<IBaseEntityRepository, BaseEntityRepository>();
            services.AddScoped<IProductsRepository, ProductsRepository>();
        }
    }
}
