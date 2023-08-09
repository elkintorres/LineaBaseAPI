// ***********************************************************************
// Assembly         : 1.Leonisa.Proyecto.Componente.API
// Author           : Arq. Elkin Torres
// Created          : 07-14-2023
//
// Last Modified By : Arq. Elkin Torres
// Last Modified On : Arq. Elkin Torres
// ***********************************************************************
// <copyright file="BaseEntityController.cs" company="1.Leonisa.Proyecto.Componente.API">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using _2.Leonisa.Proyecto.Componente.Service;

using _3.Leonisa.Proyecto.Componente.Domain;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace _1.Leonisa.Proyecto.Componente.API.Controllers
{
    /// <summary>
    /// Class BaseEntityController.
    /// Implements the <see cref="ControllerBase" />
    /// </summary>
    /// <seealso cref="ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    public class BaseEntityController : ControllerBase
    {
        /// <summary>
        /// The service
        /// </summary>
        private readonly IBaseEntityService Service;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseEntityController" /> class.
        /// </summary>
        /// <param name="service">The service.</param>
        public BaseEntityController(IBaseEntityService service)
        {
            Service = service;
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IActionResult.</returns>
        [HttpGet]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            //var jwtToken = await HttpContext.GetTokenAsync("Bearer", "access_token");

            var jwtToken = "";
            CancellationTokenSource cancellationToken = new();

            return Ok(Service.GetByExpressionAsync(x => x.BaseEntityId == id, cancellationToken, jwtToken));
        }

        /// <summary>
        /// Posts the specified register.
        /// </summary>
        /// <param name="register">The register.</param>
        /// <returns>IActionResult.</returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BaseEntity register)
        {
            var jwtToken = await HttpContext.GetTokenAsync("Bearer", "access_token");

            CancellationTokenSource cancellationToken = new();

            await Service.CreateAsync(register, cancellationToken, jwtToken);

            return StatusCode(StatusCodes.Status201Created, register.BaseEntityId);
        }

        /// <summary>
        /// Puts the specified register.
        /// </summary>
        /// <param name="register">The register.</param>
        /// <returns>IActionResult.</returns>
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] BaseEntity register)
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
        [HttpDelete]
        public async Task<IActionResult> Delete([FromRoute] int idRegister)
        {
            var jwtToken = await HttpContext.GetTokenAsync("Bearer", "access_token");

            CancellationTokenSource cancellationToken = new();

            var result = await Service.DeleteAsync(idRegister, cancellationToken, jwtToken);

            return StatusCode(StatusCodes.Status200OK, result);
        }

    }
}
