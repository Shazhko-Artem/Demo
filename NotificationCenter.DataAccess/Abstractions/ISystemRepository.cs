using System.Threading.Tasks;
using NotificationCenter.Core.Models;

namespace NotificationCenter.DataAccess.Abstractions
{
    public interface ISystemRepository
    {
        Task<SystemInfo> Get(int systemId);

        Task<int> Add(SystemInfo system);
    }
}