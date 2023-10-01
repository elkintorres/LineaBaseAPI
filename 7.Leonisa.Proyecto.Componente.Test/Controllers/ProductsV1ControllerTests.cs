using _1.Leonisa.Proyecto.Componente.API.Utilities;

using _3.Leonisa.Proyecto.Componente.Domain;

using _7.Leonisa.Proyecto.Componente.Test;
using _7.Leonisa.Proyecto.Componente.Test.Utilities;

using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Newtonsoft.Json;

using System.Net.Http.Headers;

namespace _1.Leonisa.Proyecto.Componente.API.Controllers.Tests
{
    /// <summary>
    /// La clase ProductsV1ControllerTests se utiliza para probar el controlador ProductsV1Controller.
    /// </summary>
    public class ProductsV1ControllerTests : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;
        private readonly string _url;

        /// <summary>
        /// Constructor de la clase que se ejecuta antes de cada prueba.
        /// </summary>
        /// <param name="factory"></param>
        public ProductsV1ControllerTests(CustomWebApplicationFactory<Program> factory)
        {
            // Configura la URL base de la API.
            _url = "/api/v1/Products";
            // Crea un cliente HTTP para realizar solicitudes a la API.
            _client = factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            });
            // Obtiene la configuración y establece encabezados de autorización y aceptación JSON.
            IConfiguration configuration = factory.Services.GetRequiredService<IConfiguration>();
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", new TestJWT(configuration).GenerateTokenJWT(20));
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }

        #region HTTP GET
        /// <summary>
        /// Prueba para verificar si se obtiene una respuesta exitosa (código 200 OK) al obtener un producto por ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Trait("Category", "HTTP GET")]
        [Theory]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(15)]
        [InlineData(25)]
        [InlineData(45)]
        public async Task GetById_Test_200_Ok(int id)
        {
            // Arrange
            var url = $"{_url}/GetById/{id}";
            // Act
            var responseData = await _client.GetAsync(url);
            // Assert
            responseData.EnsureSuccessStatusCode(); // Status Code 200-299
            string responseBody = await responseData.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<Products>(responseBody);

            Assert.True(responseData.StatusCode == System.Net.HttpStatusCode.OK);
            Assert.NotNull(response);
            Assert.True(response.ProductID.Equals(id));
        }

        /// <summary>
        /// Prueba para verificar si se obtiene una respuesta sin contenido (código 204 No Content) al obtener un producto por ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Trait("Category", "HTTP GET")]
        [Theory]
        [InlineData(100)]
        [InlineData(1000)]
        [InlineData(int.MaxValue)]
        public async Task GetById_Test_204_NotContent(int id)
        {
            // Arrange
            var url = $"{_url}/GetById/{id}";
            // Act
            var responseData = await _client.GetAsync(url);
            // Assert
            responseData.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.True(responseData.StatusCode == System.Net.HttpStatusCode.NoContent);
        }

        /// <summary>
        /// Prueba para verificar si se obtiene una respuesta de "no encontrado" (código 404 Not Found) al obtener un producto por ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Trait("Category", "HTTP GET")]
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(int.MinValue)]
        public async Task GetById_Test_404_NotFound(int id)
        {
            // Arrange
            var url = $"{_url}/GetById/{id}";
            // Act
            var responseData = await _client.GetAsync(url);
            // Assert
            Assert.True(responseData.StatusCode == System.Net.HttpStatusCode.NotFound);
        }

        /// <summary>
        /// Prueba para verificar si se obtiene una respuesta de "no autorizado" (código 401 Unauthorized) al obtener un producto por ID sin autenticación.
        /// </summary>
        /// <returns></returns>
        [Trait("Category", "HTTP GET")]
        [Fact]
        public async Task GetById_Test_401_Unauthorized()
        {
            // Arrange
            var url = $"{_url}/GetById/5";
            _client.DefaultRequestHeaders.Authorization = null;
            // Act
            var responseData = await _client.GetAsync(url);
            // Assert
            Assert.True(responseData.StatusCode == System.Net.HttpStatusCode.Unauthorized);
        }

        /// <summary>
        /// Prueba para verificar si se obtiene una respuesta de error interno del servidor (código 500 Internal Server Error) al obtener un producto por ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Trait("Category", "HTTP GET")]
        [Theory]
        [InlineData(30)]
        [InlineData(50)]
        public async Task GetById_Test_500_InternalServerError(int id)
        {
            // Arrange
            var url = $"{_url}/GetById/{id}";
            // Act
            var responseData = await _client.GetAsync(url);
            // Assert
            Assert.True(responseData.StatusCode == System.Net.HttpStatusCode.InternalServerError);
            string responseBody = await responseData.Content.ReadAsStringAsync();
            ErrorResult error = JsonConvert.DeserializeObject<ErrorResult>(responseBody);
            Assert.NotNull(error);
            Assert.Equal("Get_record_with_code_500_InternalServerError", error.Exception);
        }
        #endregion

        #region HTTP POST

        #endregion

        #region HTTP PUT
        #endregion

        #region HTTP DELETE
        #endregion
    }
}
