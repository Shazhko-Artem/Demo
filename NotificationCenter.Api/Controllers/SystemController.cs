using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NotificationCenter.BusinessLogic.Abstractions;
using NotificationCenter.BusinessLogic.Exceptions;
using NotificationCenter.Core.Models;

namespace NotificationCenter.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SystemController : ControllerBase
    {
        private readonly ISystemRegister register;

        public SystemController(ISystemRegister register)
        {
            this.register = register;
        }

        [HttpPost]
        public async Task<IActionResult> Register(SystemInfo systemInfo)
        {
            try
            {
                var systemId = await this.register.Register(systemInfo);
                return this.Ok(systemId);
            }
            catch (NotificationException exception)
            {
                return this.BadRequest(exception.Message);
            }
        }
    }
}