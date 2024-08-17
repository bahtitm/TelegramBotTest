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
            var inlineKeyboards = new List<List<InlineKeyboard>>
            {
                new List<InlineKeyboard>{
                    new InlineKeyboard { Text = "Services", CallbackData="1" },
                    new InlineKeyboard { Text = "Personal account", CallbackData = "2" }
                }
            };
           
            

            if (update.Message.Text == "/start")
            {
                var message = new MessageForSend
                    { ChatId=update.Message.Chat.Id,
                     Text = "Menyu",
                      ReplyMarkup=new ReplyMarkup 
                      {
                           InlineKeyboard= inlineKeyboards,
                           
                             

                      },
                     
                };
                await telegramApiService.SendMessageToBot(message);
            }
            logger.LogCritical("ok");
            var json = JsonSerializer.Serialize(update);
            logger.LogCritical(json);
            return NoContent();
        }


    }
}
