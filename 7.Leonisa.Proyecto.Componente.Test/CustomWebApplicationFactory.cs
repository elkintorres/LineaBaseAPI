using _4.Leonisa.Proyecto.Componente.Repository;

using _7.Leonisa.Proyecto.Componente.Test.Fake;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace _7.Leonisa.Proyecto.Componente.Test
{
    public class CustomWebApplicationFactory<TProgram>
    : WebApplicationFactory<TProgram> where TProgram : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder
                .ConfigureAppConfiguration(config =>
                {
                    IConfiguration Configuration = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.UnitTest.json", false, false)
                    .Build();
                    config.AddConfiguration(Configuration);
                })
                .UseEnvironment("UnitTest")
                .ConfigureTestServices(services =>
                {
                    services.Replace(ServiceDescriptor.Scoped<IProductsRepository, FakeProductsRepository>());
                });
        }
    }
}
