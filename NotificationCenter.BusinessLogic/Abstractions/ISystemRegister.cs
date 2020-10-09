using System.Threading.Tasks;
using NotificationCenter.Core.Models;

namespace NotificationCenter.BusinessLogic.Abstractions
{
    public interface ISystemRegister
    {
        Task<bool> IsRegistered(int systemId);

        Task<int> Register(SystemInfo system);
    }
}