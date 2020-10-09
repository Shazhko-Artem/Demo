using System.Data;
using System.Threading.Tasks;

namespace NotificationCenter.DataAccess.Abstractions
{
    public interface IDatabaseConnectionFactory
    {
        Task<IDbConnection> Create();
    }
}