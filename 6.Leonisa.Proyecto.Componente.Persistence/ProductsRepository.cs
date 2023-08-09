// ***********************************************************************
// Assembly         : 6.Leonisa.Proyecto.Componente.Persistence
// Author           : Arq. Elkin Torres
// Created          : 07-26-2023
//
// Last Modified By : Arq. Elkin Torres
// Last Modified On : Arq. Elkin Torres
// ***********************************************************************
// <copyright file="ProductsRepository.cs" company="6.Leonisa.Proyecto.Componente.Persistence">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using _3.Leonisa.Proyecto.Componente.Domain;

using _4.Leonisa.Proyecto.Componente.Repository;

using _6.Leonisa.Proyecto.Componente.Persistence.Base;

using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace _6.Leonisa.Proyecto.Componente.Persistence
{
    /// <summary>
    /// Class ProductsRepository.
    /// Implements the <see cref="_6.Leonisa.Proyecto.Componente.Persistence.Base.GenericRepository{_3.Leonisa.Proyecto.Componente.Domain.Products, System.Int32}" />
    /// Implements the <see cref="IProductsRepository" />
    /// </summary>
    /// <seealso cref="_6.Leonisa.Proyecto.Componente.Persistence.Base.GenericRepository{_3.Leonisa.Proyecto.Componente.Domain.Products, System.Int32}" />
    /// <seealso cref="IProductsRepository" />
    public class ProductsRepository : GenericRepository<Products, int>, IProductsRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductsRepository"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public ProductsRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public Task<int> CountAllAsync()
        {
            int count = Context.Set<Products>().Count();
            return Task.FromResult(count);
        }

        /// <summary>
        /// Gets the products paginate ef asynchronous.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="size">The size.</param>
        /// <returns>Task&lt;IEnumerable&lt;Products&gt;&gt;.</returns>
        public Task<IEnumerable<Products>> GetProductsPaginateEFAsync(int page, int size)
        {
            var offset = (page - 1) < 0 ? 0 : (page - 1);
            var fetch = size < 1 ? 1 : size;
            var result = Context.Set<Products>().OrderBy(x => x.ProductID).Skip(offset * page).Take(fetch).ToList();

            return Task.FromResult<IEnumerable<Products>>(result);
        }

        /// <summary>
        /// Gets the products paginate sp asynchronous.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="size">The size.</param>
        /// <returns>Task&lt;IEnumerable&lt;Products&gt;&gt;.</returns>
        public Task<IEnumerable<Products>> GetProductsPaginateSPAsync(int page, int size)
        {
            var SP_params = new List<SqlParameter>()
            {
                new SqlParameter("@page", page),
                new SqlParameter("@size", size)
            };

            IEnumerable<Products> result = ((APIContext)Context).Products.FromSqlRaw($"GetProductsPaginate @page, @size", parameters: SP_params.ToArray()).ToList();

            return Task.FromResult(result);
        }
    }
}
