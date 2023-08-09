// ***********************************************************************
// Assembly         : 2.Leonisa.Proyecto.Componente.Service
// Author           : Arq. Elkin Torres
// Created          : 07-14-2023
//
// Last Modified By : Arq. Elkin Torres
// Last Modified On : Arq. Elkin Torres
// ***********************************************************************
// <copyright file="BaseService.cs" company="2.Leonisa.Proyecto.Componente.Service">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using _4.Leonisa.Proyecto.Componente.Repository.Base;

using System.Linq.Expressions;

namespace _2.Leonisa.Proyecto.Componente.Service.Base
{
    /// <summary>
    /// Class BaseService.
    /// Implements the <see cref="_2.Leonisa.Proyecto.Componente.Service.Base.IBaseService{TEntity, KeyTEntity}" />
    /// </summary>
    /// <typeparam name="TEntity">The type of the t entity.</typeparam>
    /// <typeparam name="KeyTEntity">The type of the key t entity.</typeparam>
    /// <seealso cref="_2.Leonisa.Proyecto.Componente.Service.Base.IBaseService{TEntity, KeyTEntity}" />
    public class BaseService<TEntity, KeyTEntity> : IBaseService<TEntity, KeyTEntity>
    {
        /// <summary>
        /// Gets or sets the repository.
        /// </summary>
        /// <value>The repository.</value>
        protected IGenericRepository<TEntity, KeyTEntity> Repository { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseService{TEntity, KeyTEntity}"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        protected BaseService(IGenericRepository<TEntity, KeyTEntity> repository)
        {
            Repository = repository;
        }

        /// <summary>
        /// Creates the asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="token">The token.</param>
        /// <param name="jwtToken">The JWT token.</param>
        /// <returns>Task.</returns>
        public virtual Task CreateAsync(TEntity entity, CancellationTokenSource token, string jwtToken)
        {
            if (!token.IsCancellationRequested)
                return Repository.CreateAsync(entity, token);
            else
                throw new Exception("Error al ejecutar la peticion");

        }

        /// <summary>
        /// Deletes the asynchronous.
        /// </summary>
        /// <param name="entityKey">The entity key.</param>
        /// <param name="token">The token.</param>
        /// <param name="jwtToken">The JWT token.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        public virtual Task<bool> DeleteAsync(KeyTEntity entityKey, CancellationTokenSource token, string jwtToken)
        {
            return Repository.DeleteAsync(entityKey, token);
        }

        /// <summary>
        /// Gets the by expression asynchronous.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <param name="token">The token.</param>
        /// <param name="jwtToken">The JWT token.</param>
        /// <returns>Task&lt;IEnumerable&lt;TEntity&gt;&gt;.</returns>
        public virtual Task<IEnumerable<TEntity>> GetByExpressionAsync(Expression<Func<TEntity, bool>> expression, CancellationTokenSource token, string jwtToken)
        {
            return Repository.GetByExpressionAsync(expression, token);
        }

        /// <summary>
        /// Updates the asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="token">The token.</param>
        /// <param name="jwtToken">The JWT token.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        public virtual Task<bool> UpdateAsync(TEntity entity, CancellationTokenSource token, string jwtToken)
        {
            return Repository.UpdateAsync(entity, token);
        }
    }
}
