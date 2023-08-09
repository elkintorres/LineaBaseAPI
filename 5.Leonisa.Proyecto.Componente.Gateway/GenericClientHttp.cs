// ***********************************************************************
// Assembly         : 5.Leonisa.Proyecto.Componente.Gateway
// Author           : Arq. Elkin Torres
// Created          : 07-14-2023
//
// Last Modified By : Arq. Elkin Torres
// Last Modified On : Arq. Elkin Torres
// ***********************************************************************
// <copyright file="GenericClientHttp.cs" company="5.Leonisa.Proyecto.Componente.Gateway">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace _5.Leonisa.Proyecto.Componente.Gateway
{
    /// <summary>
    /// Class GenericClientHttp.
    /// Implements the <see cref="_5.Leonisa.Proyecto.Componente.Gateway.IGenericClientHttp" />
    /// </summary>
    /// <seealso cref="_5.Leonisa.Proyecto.Componente.Gateway.IGenericClientHttp" />
    public class GenericClientHttp : IGenericClientHttp
    {
        /// <summary>
        /// Deletes the request asynchronous.
        /// </summary>
        /// <typeparam name="TOut">The type of the t out.</typeparam>
        /// <param name="uri">The URI.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <param name="jwtToken">The JWT token.</param>
        /// <returns>Task&lt;TOut&gt;.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Task<TOut> DeleteRequestAsync<TOut>(string uri, CancellationTokenSource cancellationToken, string jwtToken)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the request asynchronous.
        /// </summary>
        /// <typeparam name="TOut">The type of the t out.</typeparam>
        /// <param name="uri">The URI.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <param name="jwtToken">The JWT token.</param>
        /// <returns>Task&lt;TOut&gt;.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Task<TOut> GetRequestAsync<TOut>(string uri, CancellationTokenSource cancellationToken, string jwtToken)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Posts the request asynchronous.
        /// </summary>
        /// <typeparam name="TIn">The type of the t in.</typeparam>
        /// <typeparam name="TOut">The type of the t out.</typeparam>
        /// <param name="uri">The URI.</param>
        /// <param name="content">The content.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <param name="jwtToken">The JWT token.</param>
        /// <returns>Task&lt;TOut&gt;.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Task<TOut> PostRequestAsync<TIn, TOut>(string uri, TIn content, CancellationTokenSource cancellationToken, string jwtToken)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Puts the request asynchronous.
        /// </summary>
        /// <typeparam name="TIn">The type of the t in.</typeparam>
        /// <typeparam name="TOut">The type of the t out.</typeparam>
        /// <param name="uri">The URI.</param>
        /// <param name="content">The content.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <param name="jwtToken">The JWT token.</param>
        /// <returns>Task&lt;TOut&gt;.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Task<TOut> PutRequestAsync<TIn, TOut>(string uri, TIn content, CancellationTokenSource cancellationToken, string jwtToken)
        {
            throw new NotImplementedException();
        }
    }
}
