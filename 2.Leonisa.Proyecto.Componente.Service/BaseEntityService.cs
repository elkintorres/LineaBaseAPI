// ***********************************************************************
// Assembly         : 2.Leonisa.Proyecto.Componente.Service
// Author           : Arq. Elkin Torres
// Created          : 07-14-2023
//
// Last Modified By : Arq. Elkin Torres
// Last Modified On : Arq. Elkin Torres
// ***********************************************************************
// <copyright file="BaseEntityService.cs" company="2.Leonisa.Proyecto.Componente.Service">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using _2.Leonisa.Proyecto.Componente.Service.Base;

using _3.Leonisa.Proyecto.Componente.Domain;

using _4.Leonisa.Proyecto.Componente.Repository;

namespace _2.Leonisa.Proyecto.Componente.Service
{
    /// <summary>
    /// Class BaseEntityService.
    /// Implements the <see cref="_2.Leonisa.Proyecto.Componente.Service.Base.BaseService{_3.Leonisa.Proyecto.Componente.Domain.BaseEntity, System.Int32}" />
    /// Implements the <see cref="_2.Leonisa.Proyecto.Componente.Service.IBaseEntityService" />
    /// </summary>
    /// <seealso cref="_2.Leonisa.Proyecto.Componente.Service.Base.BaseService{_3.Leonisa.Proyecto.Componente.Domain.BaseEntity, System.Int32}" />
    /// <seealso cref="_2.Leonisa.Proyecto.Componente.Service.IBaseEntityService" />
    public class BaseEntityService : BaseService<BaseEntity, int>, IBaseEntityService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseEntityService"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public BaseEntityService(IBaseEntityRepository repository) : base(repository)
        {
        }

        /// <summary>
        /// Creates the asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="token">The token.</param>
        /// <param name="jwtToken">The JWT token.</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        public override Task<int> CreateAsync(BaseEntity entity, CancellationTokenSource token, string jwtToken)
        {
            base.CreateAsync(entity, token, jwtToken);
            return Task.FromResult(entity.BaseEntityId);
        }
    }
}
