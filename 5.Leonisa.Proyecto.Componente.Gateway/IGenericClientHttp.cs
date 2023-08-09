// ***********************************************************************
// Assembly         : 5.Leonisa.Proyecto.Componente.Gateway
// Author           : Arq. Elkin Torres
// Created          : 07-14-2023
//
// Last Modified By : Arq. Elkin Torres
// Last Modified On : Arq. Elkin Torres
// ***********************************************************************
// <copyright file="IGenericClientHttp.cs" company="5.Leonisa.Proyecto.Componente.Gateway">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace _5.Leonisa.Proyecto.Componente.Gateway
{
    /// <summary>
    /// Interface IGenericClientHttp
    /// </summary>
    public interface IGenericClientHttp
    {
        /// <summary>
        /// Gets the request asynchronous.
        /// </summary>
        /// <typeparam name="TOut">The type of the t out.</typeparam>
        /// <param name="uri">The URI.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <param name="jwtToken">The JWT token.</param>
        /// <returns>Task&lt;TOut&gt;.</returns>
        Task<TOut> GetRequestAsync<TOut>(string uri, CancellationTokenSource cancellationToken, string jwtToken);
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
        Task<TOut> PostRequestAsync<TIn, TOut>(string uri, TIn content, CancellationTokenSource cancellationToken, string jwtToken);
        /// <summary>
        /// Deletes the request asynchronous.
        /// </summary>
        /// <typeparam name="TOut">The type of the t out.</typeparam>
        /// <param name="uri">The URI.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <param name="jwtToken">The JWT token.</param>
        /// <returns>Task&lt;TOut&gt;.</returns>
        Task<TOut> DeleteRequestAsync<TOut>(string uri, CancellationTokenSource cancellationToken, string jwtToken);
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
        Task<TOut> PutRequestAsync<TIn, TOut>(string uri, TIn content, CancellationTokenSource cancellationToken, string jwtToken);
    }
}
