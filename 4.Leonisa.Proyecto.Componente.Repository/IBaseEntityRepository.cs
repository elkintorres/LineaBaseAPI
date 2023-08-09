// ***********************************************************************
// Assembly         : 4.Leonisa.Proyecto.Componente.Repository
// Author           : Arq. Elkin Torres
// Created          : 07-14-2023
//
// Last Modified By : Arq. Elkin Torres
// Last Modified On : Arq. Elkin Torres
// ***********************************************************************
// <copyright file="IBaseEntityRepository.cs" company="4.Leonisa.Proyecto.Componente.Repository">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using _3.Leonisa.Proyecto.Componente.Domain;

using _4.Leonisa.Proyecto.Componente.Repository.Base;

namespace _4.Leonisa.Proyecto.Componente.Repository
{
    /// <summary>
    /// Interface IBaseEntityRepository
    /// Extends the <see cref="_4.Leonisa.Proyecto.Componente.Repository.Base.IGenericRepository{_3.Leonisa.Proyecto.Componente.Domain.BaseEntity, System.Int32}" />
    /// </summary>
    /// <seealso cref="_4.Leonisa.Proyecto.Componente.Repository.Base.IGenericRepository{_3.Leonisa.Proyecto.Componente.Domain.BaseEntity, System.Int32}" />
    public interface IBaseEntityRepository : IGenericRepository<BaseEntity, int>
    {
    }
}
