// ***********************************************************************
// Assembly         : 1.Leonisa.Proyecto.Componente.API
// Author           : Arq. Elkin Torres
// Created          : 07-26-2023
//
// Last Modified By : Arq. Elkin Torres
// Last Modified On : Arq. Elkin Torres
// ***********************************************************************
// <copyright file="ProductsController.cs" company="1.Leonisa.Proyecto.Componente.API">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using _1.Leonisa.Proyecto.Componente.API.Utilities;

using _2.Leonisa.Proyecto.Componente.Service;

using _3.Leonisa.Proyecto.Componente.Domain;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace _1.Leonisa.Proyecto.Componente.API.Controllers
{

    /// <summary>
    /// Class ProductsController.
    /// Implements the <see cref="ControllerBase" />
    /// </summary>
    /// <seealso cref="ControllerBase" />
    //[Authorize]
    [Produces("application/json")]
    [Consumes("application/json")]
    [ApiController]
    [ControllerName("Products")]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/Products")]

    //[ApiExplorerSettings(GroupName = "V1")]
    public class ProductsV1Controller : ControllerBase
    {
        /// <summary>
        /// The service
        /// </summary>
        private readonly IProductsService Service;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductsV1Controller" /> class.
        /// </summary>
        /// <param name="service">The service.</param>
        public ProductsV1Controller(IProductsService service)
        {
            Service = service;
        }

        /// <summary>
        /// Este endpoint permite obtener la información de un producto específico a partir de su identificador.
        /// El identificador se pasa como parámetro en la ruta de la petición.
        /// </summary>
        /// <param name="id">Id del registro de la entidad Products (min: 1)</param>
        /// <returns>IActionResult.</returns>
        /// <response code="200">El código de respuesta 200 indica que el proceso se realizó correctamente y que se devuelve el registro que cumplen con el id del filtro proporcionado.</response>
        /// <response code="204">El código de respuesta 204 indica que el recurso solicitado con el id del filtro, no se pudo encontrar en el servicio.</response>
        /// <response code="400">El código de respuesta 400 indica que el registro es incorrecto en cualquier campo y que el servidor no procesa la solicitud.</response>
        /// <response code="401">El código de respuesta 401 indica que no se encuentra autorizado para acceder al recurso, y el servidor no procesa la solicitud.</response>
        /// <response code="500">El código de respuesta 500 indica que se produjo un error interno durante el procesamiento de la solicitud en el servicio y que la respuesta contiene una descripción del error.</response>
        /// <remarks>Ejemplo de petición:
        /// .../api/Products/GetById/5</remarks>
        [MapToApiVersion("1.0")]
        [HttpGet, Route("GetById/{id:int:min(1)}")]
        [Authorize(Policy = "Products_Read")]
        [ProducesResponseType(typeof(Products), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var jwtToken = await HttpContext.GetTokenAsync("Bearer", "access_token");

            CancellationTokenSource cancellationToken = new();

            var result = await Service.GetByExpressionAsync(x => x.ProductID == id, cancellationToken, jwtToken);

            if (!result.Any())
                return NoContent();

            return Ok(result.FirstOrDefault());
        }

        /// <summary>
        /// Gets the products paginate ef.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="size">The size.</param>
        /// <returns>IActionResult.</returns>
        [MapToApiVersion("1.0")]
        [Obsolete("This version is deprecated. Use version 2.0 instead.")]
        [HttpGet, Route("GetProductsPaginateEF/{page:int:min(1)}/{size:int:min(1)}")]
        [Authorize(Policy = "Products_Read")]
        [ProducesResponseType(typeof(IEnumerable<Products>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetProductsPaginateEF([FromRoute] int page, int size)
        {
            var result = await Service.GetProductsPaginateEFAsync(page, size);

            if (!result.Any())
                return NoContent();

            int totalItems = await Service.CountAllAsync();
            Response.Headers.Add("X-Total-Items", totalItems.ToString());

            return Ok(result);
        }

        /// <summary>
        /// Posts the specified register.
        /// </summary>
        /// <param name="register">The register.</param>
        /// <returns>IActionResult.</returns>
        [MapToApiVersion("1.0")]
        [HttpPost, Route("Post")]
        [Authorize(Policy = "Products_Create")]
        [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] Products register)
        {
            var jwtToken = await HttpContext.GetTokenAsync("Bearer", "access_token");

            CancellationTokenSource cancellationToken = new();

            await Service.CreateAsync(register, cancellationToken, jwtToken);

            return StatusCode(StatusCodes.Status201Created, register.ProductID);
        }

        /// <summary>
        /// Puts the specified register.
        /// </summary>
        /// <param name="register">The register.</param>
        /// <returns>IActionResult.</returns>
        [MapToApiVersion("1.0")]
        [HttpPut, Route("Put")]
        [Authorize(Policy = "Products_Update")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put([FromBody] Products register)
        {
            var jwtToken = await HttpContext.GetTokenAsync("Bearer", "access_token");

            CancellationTokenSource cancellationToken = new();

            var result = await Service.UpdateAsync(register, cancellationToken, jwtToken);

            return StatusCode(StatusCodes.Status200OK, result);
        }

        /// <summary>
        /// Deletes the specified identifier register.
        /// </summary>
        /// <param name="idRegister">The identifier register.</param>
        /// <returns>IActionResult.</returns>
        [MapToApiVersion("1.0")]
        [HttpDelete, Route("Delete/{idRegister}")]
        [Authorize(Policy = "BaseEntity_Delete")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete([FromRoute] int idRegister)
        {
            var jwtToken = await HttpContext.GetTokenAsync("Bearer", "access_token");

            CancellationTokenSource cancellationToken = new();

            var result = await Service.DeleteAsync(idRegister, cancellationToken, jwtToken);

            return StatusCode(StatusCodes.Status200OK, result);
        }
    }
}
