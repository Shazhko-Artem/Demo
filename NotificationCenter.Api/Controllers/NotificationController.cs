using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NotificationCenter.BusinessLogic.Abstractions;
using NotificationCenter.BusinessLogic.Exceptions;
using NotificationCenter.Core.Models;

namespace NotificationCenter.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationManager manager;

        public NotificationController(INotificationManager manager)
        {
            this.manager = manager;
        }

        [HttpPost]
        public async Task<IActionResult> Add(Notification notification)
        {
            try
            {
                var notificationId = await this.manager.Add(notification);
                return this.Ok(notificationId);
            }
            catch (NotificationException exception)
            {
                return this.BadRequest(exception.Message);
            }
        }
    }
}