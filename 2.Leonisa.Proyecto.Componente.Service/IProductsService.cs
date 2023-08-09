// ***********************************************************************
// Assembly         : 2.Leonisa.Proyecto.Componente.Service
// Author           : Arq. Elkin Torres
// Created          : 07-26-2023
//
// Last Modified By : Arq. Elkin Torres
// Last Modified On : Arq. Elkin Torres
// ***********************************************************************
// <copyright file="IProductsService.cs" company="2.Leonisa.Proyecto.Componente.Service">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using _2.Leonisa.Proyecto.Componente.Service.Base;

using _3.Leonisa.Proyecto.Componente.Domain;

namespace _2.Leonisa.Proyecto.Componente.Service
{
    /// <summary>
    /// Interface IProductsService
    /// Extends the <see cref="_2.Leonisa.Proyecto.Componente.Service.Base.IBaseService{_3.Leonisa.Proyecto.Componente.Domain.Products, System.Int32}" />
    /// </summary>
    /// <seealso cref="_2.Leonisa.Proyecto.Componente.Service.Base.IBaseService{_3.Leonisa.Proyecto.Componente.Domain.Products, System.Int32}" />
    public interface IProductsService : IBaseService<Products, int>
    {
        Task<int> CountAllAsync();
        Task<IEnumerable<Products>> GetProductsPaginateEFAsync(int page, int size);
        Task<IEnumerable<Products>> GetProductsPaginateSPAsync(int page, int size);
    }
}