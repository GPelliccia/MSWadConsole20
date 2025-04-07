using Microsoft.Data.SqlClient;
using System.Data;

namespace MSWadConsole20.Repository.Connection
{
    public interface IConnectionFactory
    {
        IDbConnection CreateConnection();
    }

    public class SqlConnectionFactory(IConfiguration configuration, string connectionStringName) : IConnectionFactory
    {
        private readonly string _connectionString = configuration?.GetConnectionString(connectionStringName);

        public IDbConnection CreateConnection()
        {
            var connection = new SqlConnection(_connectionString);
            connection.Open();
            return connection;
        }
    }
}
