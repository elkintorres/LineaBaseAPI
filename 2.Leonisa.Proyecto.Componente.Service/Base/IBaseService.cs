// ***********************************************************************
// Assembly         : 2.Leonisa.Proyecto.Componente.Service
// Author           : Arq. Elkin Torres
// Created          : 07-14-2023
//
// Last Modified By : Arq. Elkin Torres
// Last Modified On : Arq. Elkin Torres
// ***********************************************************************
// <copyright file="IBaseService.cs" company="2.Leonisa.Proyecto.Componente.Service">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Linq.Expressions;

namespace _2.Leonisa.Proyecto.Componente.Service.Base
{
    /// <summary>
    /// Interface IBaseService
    /// </summary>
    /// <typeparam name="TEntity">The type of the t entity.</typeparam>
    /// <typeparam name="KeyTEntity">The type of the key t entity.</typeparam>
    public interface IBaseService<TEntity, KeyTEntity>
    {
        /// <summary>
        /// Creates the asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="token">The token.</param>
        /// <param name="jwtToken">The JWT token.</param>
        /// <returns>Task.</returns>
        Task CreateAsync(TEntity entity, CancellationTokenSource token, string jwtToken);
        /// <summary>
        /// Deletes the asynchronous.
        /// </summary>
        /// <param name="entityKey">The entity key.</param>
        /// <param name="token">The token.</param>
        /// <param name="jwtToken">The JWT token.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        Task<bool> DeleteAsync(KeyTEntity entityKey, CancellationTokenSource token, string jwtToken);
        /// <summary>
        /// Gets the by expression asynchronous.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <param name="token">The token.</param>
        /// <param name="jwtToken">The JWT token.</param>
        /// <returns>Task&lt;IEnumerable&lt;TEntity&gt;&gt;.</returns>
        Task<IEnumerable<TEntity>> GetByExpressionAsync(Expression<Func<TEntity, bool>> expression, CancellationTokenSource token, string jwtToken);
        /// <summary>
        /// Updates the asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="token">The token.</param>
        /// <param name="jwtToken">The JWT token.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        Task<bool> UpdateAsync(TEntity entity, CancellationTokenSource token, string jwtToken);
    }
}
