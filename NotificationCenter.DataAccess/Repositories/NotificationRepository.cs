using Dapper;
using NotificationCenter.Core.Models;
using NotificationCenter.DataAccess.Abstractions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationCenter.DataAccess.Repositories
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly IDatabaseConnectionFactory connectionFactory;

        public NotificationRepository(IDatabaseConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<Notification>> GetAll()
        {
            var commandText = Sql.Scripts.GetAllNotifications;

            using var connection = await this.connectionFactory.Create();
            var reader = await connection.ExecuteReaderAsync(commandText);
            return reader.Parse<Notification>().ToList();
        }

        public async Task<int> Add(Notification notification)
        {
            var commandText = Sql.Scripts.AddNotification;

            var parameters = new DynamicParameters();
            parameters.Add(Constants.Parameters.SystemId, notification.SystemId);
            parameters.Add(Constants.Parameters.Message, notification.Message);

            using var connection = await this.connectionFactory.Create();
            return await connection.ExecuteScalarAsync<int>(commandText, parameters);
        }

        private static class Constants
        {
            public static class Parameters
            {
                public const string SystemId = "@SystemId";
                public const string Message = "@Message";
            }
        }
    }
}