using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Diagnostics.HealthChecks;

using System.Data.Common;

namespace _1.Leonisa.Proyecto.Componente.API.Utilities.HealthCheck
{
    /// <summary>
    /// Health Check personalizado para verificar la conexión a una base de datos SQL.
    /// </summary>
    public class SqlConnectionHealthCheck : IHealthCheck
    {
        private const string DefaultTestQuery = "Select 1";

        /// <summary>
        /// Cadena de conexión a la base de datos SQL.
        /// </summary>
        public string ConnectionString { get; }

        /// <summary>
        /// Consulta de prueba a ejecutar para verificar la conexión (opcional).
        /// </summary>
        public string TestQuery { get; }

        /// <summary>
        /// Constructor que acepta la cadena de conexión a la base de datos.
        /// </summary>
        /// <param name="connectionString">Cadena de conexión a la base de datos.</param>
        public SqlConnectionHealthCheck(string connectionString)
            : this(connectionString, testQuery: DefaultTestQuery)
        {
        }

        /// <summary>
        /// Constructor que acepta la cadena de conexión y una consulta de prueba personalizada.
        /// </summary>
        /// <param name="connectionString">Cadena de conexión a la base de datos.</param>
        /// <param name="testQuery">Consulta de prueba personalizada.</param>
        public SqlConnectionHealthCheck(string connectionString, string testQuery)
        {
            ConnectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
            TestQuery = testQuery;
        }

        /// <summary>
        /// Método que realiza la verificación de salud de la conexión a la base de datos.
        /// </summary>
        /// <param name="context">Contexto del health check.</param>
        /// <param name="cancellationToken">Token de cancelación.</param>
        /// <returns>Resultado del health check.</returns>
        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    await connection.OpenAsync(cancellationToken);

                    if (TestQuery != null)
                    {
                        var command = connection.CreateCommand();
                        command.CommandText = TestQuery;

                        await command.ExecuteNonQueryAsync(cancellationToken);
                    }
                }
                catch (DbException ex)
                {
                    // Si ocurre una excepción al intentar conectar o ejecutar la consulta,
                    // el health check devuelve un resultado de error.
                    return new HealthCheckResult(status: context.Registration.FailureStatus, exception: ex);
                }
            }

            // Si la conexión y la consulta se realizan con éxito, el health check devuelve un resultado saludable.
            return HealthCheckResult.Healthy();
        }
    }
}
