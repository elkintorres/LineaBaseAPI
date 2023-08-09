// ***********************************************************************
// Assembly         : 6.Leonisa.Proyecto.Componente.Persistence
// Author           : Arq. Elkin Torres
// Created          : 07-14-2023
//
// Last Modified By : Arq. Elkin Torres
// Last Modified On : Arq. Elkin Torres
// ***********************************************************************
// <copyright file="GenericRepository.cs" company="6.Leonisa.Proyecto.Componente.Persistence">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using _4.Leonisa.Proyecto.Componente.Repository.Base;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using System.Linq.Expressions;

namespace _6.Leonisa.Proyecto.Componente.Persistence.Base
{
    /// <summary>
    /// Class GenericRepository.
    /// Implements the <see cref="IGenericRepository{TEntity, Tkey}" />
    /// </summary>
    /// <typeparam name="TEntity">The type of the t entity.</typeparam>
    /// <typeparam name="Tkey">The type of the tkey.</typeparam>
    /// <seealso cref="IGenericRepository{TEntity, Tkey}" />
    public abstract class GenericRepository<TEntity, Tkey> : IGenericRepository<TEntity, Tkey> where TEntity : class, new()
    {
        /// <summary>
        /// Gets or sets the context.
        /// </summary>
        /// <value>The context.</value>
        protected DbContext Context { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericRepository{TEntity, Tkey}"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        protected GenericRepository(IConfiguration configuration)
        {
            Context = new APIContext(connectionString: configuration.GetConnectionString("ConnectionString"));
        }

        /// <summary>
        /// Create as an asynchronous operation.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task representing the asynchronous operation.</returns>
        /// <exception cref="System.Exception">Error al insertar el registro en la BD</exception>
        public virtual async Task CreateAsync(TEntity entity, CancellationTokenSource cancellationToken)
        {
            try
            {
                if (!cancellationToken.IsCancellationRequested)
                {
                    Context.Set<TEntity>().Add(entity);
                    Context.SaveChanges();
                }
            }
            catch (Exception exc)
            {
                cancellationToken.Cancel(true);
                throw new Exception("Error al insertar el registro en la BD", exc);
            }

        }

        /// <summary>
        /// Deletes the asynchronous.
        /// </summary>
        /// <param name="entityKey">The entity key.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public virtual Task<bool> DeleteAsync(Tkey entityKey, CancellationTokenSource cancellationToken)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the by expression asynchronous.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Task&lt;IEnumerable&lt;TEntity&gt;&gt;.</returns>
        /// <exception cref="System.Exception">Error al obtener los registro desde la BD</exception>
        public virtual Task<IEnumerable<TEntity>> GetByExpressionAsync(Expression<Func<TEntity, bool>> predicate, CancellationTokenSource cancellationToken)
        {
            try
            {
                IEnumerable<TEntity> result = new List<TEntity>();
                if (!cancellationToken.Token.IsCancellationRequested)
                {
                    result = Context.Set<TEntity>().Where(predicate).ToList();
                }
                return Task.FromResult(result);
            }
            catch (Exception exc)
            {
                cancellationToken.Cancel(true);
                throw new Exception("Error al obtener los registro desde la BD", exc);
            }
        }

        /// <summary>
        /// Updates the asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public virtual Task<bool> UpdateAsync(TEntity entity, CancellationTokenSource cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
