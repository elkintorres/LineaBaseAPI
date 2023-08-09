// ***********************************************************************
// Assembly         : 2.Leonisa.Proyecto.Componente.Service
// Author           : Arq. Elkin Torres
// Created          : 07-26-2023
//
// Last Modified By : Arq. Elkin Torres
// Last Modified On : Arq. Elkin Torres
// ***********************************************************************
// <copyright file="ProductsService.cs" company="2.Leonisa.Proyecto.Componente.Service">
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
    /// Class ProductsService.
    /// Implements the <see cref="_2.Leonisa.Proyecto.Componente.Service.Base.BaseService{_3.Leonisa.Proyecto.Componente.Domain.Products, System.Int32}" />
    /// Implements the <see cref="_2.Leonisa.Proyecto.Componente.Service.IProductsService" />
    /// </summary>
    /// <seealso cref="_2.Leonisa.Proyecto.Componente.Service.Base.BaseService{_3.Leonisa.Proyecto.Componente.Domain.Products, System.Int32}" />
    /// <seealso cref="_2.Leonisa.Proyecto.Componente.Service.IProductsService" />
    public class ProductsService : BaseService<Products, int>, IProductsService
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductsService"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public ProductsService(IProductsRepository repository) : base(repository)
        {
        }

        public IProductsRepository ProductsRepository
        {
            get { return (IProductsRepository)this.Repository; }
        }

        public Task<int> CountAllAsync()
        {
            return ProductsRepository.CountAllAsync();
        }

        public Task<IEnumerable<Products>> GetProductsPaginateEFAsync(int page, int size)
        {
            return ProductsRepository.GetProductsPaginateEFAsync(page, size);
        }

        public Task<IEnumerable<Products>> GetProductsPaginateSPAsync(int page, int size)
        {
            return ProductsRepository.GetProductsPaginateSPAsync(page, size);
        }
    }
}