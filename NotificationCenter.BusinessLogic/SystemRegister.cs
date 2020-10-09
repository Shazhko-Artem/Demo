using NotificationCenter.BusinessLogic.Abstractions;
using NotificationCenter.Core.Models;
using NotificationCenter.DataAccess.Abstractions;
using System.Threading.Tasks;

namespace NotificationCenter.BusinessLogic
{
    public class SystemRegister : ISystemRegister
    {
        private readonly ISystemRepository repository;

        public SystemRegister(ISystemRepository repository)
        {
            this.repository = repository;
        }

        public async Task<bool> IsRegistered(int systemId)
        {
            var system = await this.repository.Get(systemId);
            return system != null;
        }

        public Task<int> Register(SystemInfo system)
        {
            return this.repository.Add(system);
        }
    }
}