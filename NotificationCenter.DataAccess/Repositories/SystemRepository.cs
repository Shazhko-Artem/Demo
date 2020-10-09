using Dapper;
using NotificationCenter.Core.Models;
using NotificationCenter.DataAccess.Abstractions;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationCenter.DataAccess.Repositories
{
    public class SystemRepository : ISystemRepository
    {
        private readonly IDatabaseConnectionFactory connectionFactory;

        public SystemRepository(IDatabaseConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public async Task<SystemInfo> Get(int systemId)
        {
            var commandText = Sql.Scripts.GetSystemById;
            var parameters = new DynamicParameters();
            parameters.Add(Constants.Parameters.SystemId, systemId);

            using var connection = await this.connectionFactory.Create();
            var reader = await connection.ExecuteReaderAsync(commandText, parameters);
            return reader.Parse<SystemInfo>().FirstOrDefault();
        }

        public async Task<int> Add(SystemInfo system)
        {
            var commandText = Sql.Scripts.AddSystem;
            var parameters = new DynamicParameters();
            parameters.Add(Constants.Parameters.SystemName, system.Name);

            using var connection = await this.connectionFactory.Create();
            return await connection.ExecuteScalarAsync<int>(commandText, parameters);
        }

        private static class Constants
        {
            public static class Parameters
            {
                public const string SystemId = "@SystemId";
                public const string SystemName = "@Name";
            }
        }
    }
}