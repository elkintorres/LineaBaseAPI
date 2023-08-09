// ***********************************************************************
// Assembly         : 6.Leonisa.Proyecto.Componente.Persistence
// Author           : Arq. Elkin Torres
// Created          : 07-14-2023
//
// Last Modified By : Arq. Elkin Torres
// Last Modified On : Arq. Elkin Torres
// ***********************************************************************
// <copyright file="BaseEntityRepository.cs" company="6.Leonisa.Proyecto.Componente.Persistence">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using _3.Leonisa.Proyecto.Componente.Domain;

using _4.Leonisa.Proyecto.Componente.Repository;

using _6.Leonisa.Proyecto.Componente.Persistence.Base;

using Microsoft.Extensions.Configuration;

using System.Linq.Expressions;

namespace _6.Leonisa.Proyecto.Componente.Persistence
{
    /// <summary>
    /// Class BaseEntityRepository.
    /// Implements the <see cref="_6.Leonisa.Proyecto.Componente.Persistence.Base.GenericRepository{_3.Leonisa.Proyecto.Componente.Domain.BaseEntity, System.Int32}" />
    /// Implements the <see cref="IBaseEntityRepository" />
    /// </summary>
    /// <seealso cref="_6.Leonisa.Proyecto.Componente.Persistence.Base.GenericRepository{_3.Leonisa.Proyecto.Componente.Domain.BaseEntity, System.Int32}" />
    /// <seealso cref="IBaseEntityRepository" />
    public class BaseEntityRepository : GenericRepository<BaseEntity, int>, IBaseEntityRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseEntityRepository"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public BaseEntityRepository(IConfiguration configuration) : base(configuration)
        {

        }

        /// <summary>
        /// Gets the by expression asynchronous.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Task&lt;IEnumerable&lt;BaseEntity&gt;&gt;.</returns>
        public override Task<IEnumerable<BaseEntity>> GetByExpressionAsync(Expression<Func<BaseEntity, bool>> predicate, CancellationTokenSource cancellationToken)
        {
            return base.GetByExpressionAsync(predicate, cancellationToken);
        }
    }
}
