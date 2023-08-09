// ***********************************************************************
// Assembly         : 4.Leonisa.Proyecto.Componente.Repository
// Author           : Arq. Elkin Torres
// Created          : 07-26-2023
//
// Last Modified By : Arq. Elkin Torres
// Last Modified On : Arq. Elkin Torres
// ***********************************************************************
// <copyright file="IProductsRepository.cs" company="4.Leonisa.Proyecto.Componente.Repository">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using _3.Leonisa.Proyecto.Componente.Domain;

using _4.Leonisa.Proyecto.Componente.Repository.Base;

namespace _4.Leonisa.Proyecto.Componente.Repository
{
    /// <summary>
    /// Interface IProductsRepository
    /// Extends the <see cref="_4.Leonisa.Proyecto.Componente.Repository.Base.IGenericRepository{_3.Leonisa.Proyecto.Componente.Domain.Products, System.Int32}" />
    /// </summary>
    /// <seealso cref="_4.Leonisa.Proyecto.Componente.Repository.Base.IGenericRepository{_3.Leonisa.Proyecto.Componente.Domain.Products, System.Int32}" />
    public interface IProductsRepository : IGenericRepository<Products, int>
    {
        Task<int> CountAllAsync();
        Task<IEnumerable<Products>> GetProductsPaginateEFAsync(int page, int size);
        Task<IEnumerable<Products>> GetProductsPaginateSPAsync(int page, int size);
    }
}
