using NotificationCenter.BusinessLogic.Abstractions;
using NotificationCenter.Core.Models;
using NotificationCenter.DataAccess.Abstractions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NotificationCenter.BusinessLogic.Exceptions;

namespace NotificationCenter.BusinessLogic
{
    public class NotificationManager : INotificationManager
    {
        private readonly INotificationRepository repository;
        private readonly ISystemRegister systemRegister;

        public NotificationManager(INotificationRepository repository, ISystemRegister systemRegister)
        {
            this.repository = repository;
            this.systemRegister = systemRegister;
        }

        public async Task<int> Add(Notification notification)
        {
            await this.Validate(notification);
            return await this.repository.Add(notification);
        }

        public Task<IEnumerable<Notification>> GetAll()
        {
            return this.repository.GetAll();
        }

        private async Task Validate(Notification notification)
        {
            var systemExisted = await this.systemRegister.IsRegistered(notification.SystemId);
            if (!systemExisted)
            {
                throw new NotificationException("The specified system is not registered.");
            }
        }
    }
}