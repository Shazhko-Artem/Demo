using System.Collections.Generic;
using System.Threading.Tasks;
using NotificationCenter.Core.Models;

namespace NotificationCenter.DataAccess.Abstractions
{
    public interface INotificationRepository
    {
        Task<IEnumerable<Notification>> GetAll();

        Task<int> Add(Notification notification);
    }
}