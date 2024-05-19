using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Infrastructure.Common
{
    public class ConnectionFactory : IDisposable
    {
        public IDbConnection Connection { get; }
        public IDbTransaction Transaction { get; set; }
        public ConnectionFactory(IConfiguration _configuration)
        {
            Connection = new SqlConnection(_configuration.GetConnectionString("nucleotidz"));
            Connection.Open();
        }

        public void Dispose() => Connection?.Dispose();
    }
}
