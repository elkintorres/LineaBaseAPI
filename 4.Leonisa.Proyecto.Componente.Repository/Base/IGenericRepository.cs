// ***********************************************************************
// Assembly         : 4.Leonisa.Proyecto.Componente.Repository
// Author           : Arq. Elkin Torres
// Created          : 07-14-2023
//
// Last Modified By : Arq. Elkin Torres
// Last Modified On : Arq. Elkin Torres
// ***********************************************************************
// <copyright file="IGenericRepository.cs" company="4.Leonisa.Proyecto.Componente.Repository">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Linq.Expressions;

namespace _4.Leonisa.Proyecto.Componente.Repository.Base
{
    /// <summary>
    /// Interface IGenericRepository
    /// </summary>
    /// <typeparam name="TEntity">The type of the t entity.</typeparam>
    /// <typeparam name="Tkey">The type of the tkey.</typeparam>
    public interface IGenericRepository<TEntity, Tkey>
    {
        /// <summary>
        /// Creates the asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Task.</returns>
        Task CreateAsync(TEntity entity, CancellationTokenSource cancellationToken);
        /// <summary>
        /// Updates the asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        Task<bool> UpdateAsync(TEntity entity, CancellationTokenSource cancellationToken);
        /// <summary>
        /// Deletes the asynchronous.
        /// </summary>
        /// <param name="entityKey">The entity key.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        Task<bool> DeleteAsync(Tkey entityKey, CancellationTokenSource cancellationToken);
        /// <summary>
        /// Gets the by expression asynchronous.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Task&lt;IEnumerable&lt;TEntity&gt;&gt;.</returns>
        Task<IEnumerable<TEntity>> GetByExpressionAsync(Expression<Func<TEntity, bool>> predicate, CancellationTokenSource cancellationToken);
    }
}
