using Microsoft.Extensions.Options;
using NotificationCenter.Core.Options;
using NotificationCenter.DataAccess.Abstractions;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace NotificationCenter.DataAccess
{
    public class DatabaseConnectionFactory: IDatabaseConnectionFactory
    {
        private readonly DatabaseOptions options;

        public DatabaseConnectionFactory(IOptionsSnapshot<DatabaseOptions> options)
        {
            this.options = options.Value;
        }

        public async Task<IDbConnection> Create()
        {
            var connection = new SqlConnection(this.options.ConnectionString);
            await connection.OpenAsync();

            return connection;
        }
    }
}