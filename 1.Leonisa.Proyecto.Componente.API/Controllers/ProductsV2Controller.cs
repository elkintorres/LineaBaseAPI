using _1.Leonisa.Proyecto.Componente.API.Utilities;

using _2.Leonisa.Proyecto.Componente.Service;

using _3.Leonisa.Proyecto.Componente.Domain;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace _1.Leonisa.Proyecto.Componente.API.Controllers
{
    /// <summary>
    /// Class ProductsController.
    /// Implements the <see cref="ControllerBase" />
    /// </summary>
    /// <seealso cref="ControllerBase" />
    [Authorize]
    [Produces("application/json")]
    [Consumes("application/json")]
    [ApiController]
    [ControllerName("Products")]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/Products")]

    public class ProductsV2Controller : ControllerBase
    {
        /// <summary>
        /// The service
        /// </summary>
        private readonly IProductsService Service;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductsV1Controller" /> class.
        /// </summary>
        /// <param name="service">The service.</param>
        public ProductsV2Controller(IProductsService service)
        {
            Service = service;
        }

        /// <summary>
        /// Gets the products paginate ef.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="size">The size.</param>
        /// <returns>IActionResult.</returns>
        [MapToApiVersion("2.0")]
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
    }
}
