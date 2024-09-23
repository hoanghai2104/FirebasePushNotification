using FirebasePushNotification.Interfaces;
using FirebasePushNotification.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace FirebasePushNotification.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly IPushService _pushService;
        public NotificationController(IPushService pushService)
        {
            _pushService = pushService;
        }

        [HttpGet("Ping")]
        public async Task<string> Ping()
        {
            return "Pong";
        }

        [HttpPost("Push")]
        public async Task<IActionResult> Push(MessageRequest request)
        {
            try
            {
                var response = await _pushService.SendMessage(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.InnerException is null ? ex.Message : ex.InnerException.Message);
            }
        }
    }
}
