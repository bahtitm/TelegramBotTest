using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using TelegramBotTest.Services;

namespace TelegramBotTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class WebhookController : BaseController
    {

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Update update)
        {
            logger.LogCritical("ok");
            var json = JsonSerializer.Serialize(update);
            logger.LogCritical(json);
            return NoContent();
        }


    }
}
