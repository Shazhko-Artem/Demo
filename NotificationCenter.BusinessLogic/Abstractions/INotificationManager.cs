using System.Collections.Generic;
using System.Threading.Tasks;
using NotificationCenter.Core.Models;

namespace NotificationCenter.BusinessLogic.Abstractions
{
    public interface INotificationManager
    {
        Task<int> Add(Notification notification);

        Task<IEnumerable<Notification>> GetAll();
    }
}